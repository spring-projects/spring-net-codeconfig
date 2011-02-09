#region License

/*
 * Copyright � 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using NUnit.Framework;
using Spring.Context.Support;
using Spring.Objects.Factory.Parsing;

namespace Spring.Context.Attributes
{
    [TestFixture]
    public class FailAssemblyObjectDefinitionScannerTests
    {
        #region Setup/Teardown

        [SetUp]
        public void _SetUp()
        {
            _scanner = new AssemblyObjectDefinitionScanner();
            _context = new CodeConfigApplicationContext();
        }

        #endregion

        private void ScanForAndRegisterSingleType(Type type)
        {
            _scanner.WithIncludeFilter(t => t.Name == type.Name);
            _scanner.ScanAndRegisterTypes(_context.DefaultListableObjectFactory);
        }

        private CodeConfigApplicationContext _context;
        private AssemblyObjectDefinitionScanner _scanner;

        [Test]
        public void Can_Ignore_Abstract_Configuration_Types()
        {
            ScanForAndRegisterSingleType(typeof (ConfigurationClassThatIsAbstract));
            Assert.That(_context.GetObjectNamesForType(typeof (ConfigurationClassThatIsAbstract)).Length, Is.EqualTo(0),
                        "Abstract Type erroneously registered with the Context.");
        }

        [Test]
        public void Can_Prevent_Methods_With_Parameters()
        {
            ScanForAndRegisterSingleType(typeof (ConfigurationClassWithMethodHavingParameters));
            Assert.Throws<ObjectDefinitionParsingException>(_context.Refresh);
        }

        [Test]
        public void Can_Prevent_Non_Virtual_Methods()
        {
            ScanForAndRegisterSingleType(typeof (ConfigurationClassWithNonVirtualMethod));
            Assert.Throws<ObjectDefinitionParsingException>(_context.Refresh);
        }

        [Test]
        public void Can_Prevent_Sealed_Configuration_Types()
        {
            ScanForAndRegisterSingleType(typeof (ConfigurationClassThatIsSealed));
            Assert.Throws<ObjectDefinitionParsingException>(_context.Refresh);
        }
    }

    public class SomeType
    {
    }


    [Configuration]
    public class ConfigurationClassWithNonVirtualMethod
    {
        [Definition]
        public SomeType MethodThatRegistersSomeType()
        {
            return new SomeType();
        }
    }

    [Configuration]
    public class ConfigurationClassWithMethodHavingParameters
    {
        [Definition]
        public virtual SomeType MethodThatRegistersSomeType(int i)
        {
            return new SomeType();
        }
    }


    [Configuration]
    public abstract class ConfigurationClassThatIsAbstract
    {
        [Definition]
        public virtual SomeType MethodThatRegistersSomeType()
        {
            return new SomeType();
        }
    }

    [Configuration]
    public sealed class ConfigurationClassThatIsSealed
    {
        [Definition]
        public SomeType MethodThatRegistersSomeType()
        {
            return new SomeType();
        }
    }
}