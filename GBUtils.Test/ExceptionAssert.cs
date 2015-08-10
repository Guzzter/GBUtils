// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionAssert.cs" company="Guus Beltman">
//   2015
// </copyright>
// <summary>
//   Helper class for exceptions. This has two benefits:
//   - it verifies that the exception is thrown on the line you were expecting it to be thrown instead of anywhere in your test method.
//   - easy check of message and parameter possible
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GBUtils.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Helper class for exceptions. This has two benefits: 
    /// - it verifies that the exception is thrown on the line you were expecting it to be thrown instead of anywhere in your test method.
    /// - easy check of message and parameter possible
    /// </summary>
    public static class ExceptionAssert
    {
        /// <summary>
        /// Execute an action which should throw an exception
        /// </summary>
        /// <param name="action">
        /// The action that should throw the exception
        /// </param>
        /// <typeparam name="T">
        /// Type of the exception exception
        /// </typeparam>
        /// <returns>
        /// The captured exception or null when no exception is thrown
        /// </returns>
        public static T Throws<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }

            Assert.Fail("Exception of type {0} should be thrown.", typeof(T));

            // The compiler doesn't know that Assert.Fail
            // will always throw an exception
            return null;
        }
    }
}
