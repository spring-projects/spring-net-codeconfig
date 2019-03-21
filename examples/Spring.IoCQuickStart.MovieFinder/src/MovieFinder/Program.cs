#region License

/*
 * Copyright 2002-2006 the original author or authors.
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

#region Imports

using System;
using Common.Logging;
using Spring.Context;
using Spring.Context.Support;

#endregion

namespace Spring.IocQuickStart.MovieFinder
{
    /// <summary>
    /// A simple application that demonstrates the IoC functionality of Spring.NET.
    /// </summary>
    /// <remarks>
    /// <p>
    /// See <a href="https://martinfowler.com/articles/injection.html"/> for the background
    /// article on which this example application is based.
    /// </p>
    /// </remarks>
    public sealed class Program
    {
        #region Logging Definition

        private static readonly ILog LOG = LogManager.GetLogger(typeof (Program));

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                IApplicationContext ctx = ContextRegistry.GetContext();

                MovieLister lister = ctx.GetObject<MovieLister>();
                Movie[] movies = lister.MoviesDirectedBy("Roberto Benigni");
                LOG.Debug("Searching for movie...");
                foreach (Movie movie in movies)
                {
                    LOG.Debug(
                        string.Format("Movie Title = '{0}', Director = '{1}'.",
                                      movie.Title, movie.Director));
                }
                LOG.Debug("MovieApp Done.");
            }
            catch (Exception e)
            {
                LOG.Error("Movie Finder is broken.", e);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("--- hit <return> to quit ---");
                Console.ReadLine();
            }
        }
    }
}