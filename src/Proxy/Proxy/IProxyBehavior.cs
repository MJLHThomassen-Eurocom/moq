﻿namespace Moq.Proxy
{
    /// <summary>
    /// A configured behavior for a proxy.
    /// </summary>
	public interface IProxyBehavior
	{
        /// <summary>
        /// Determines whether the behavior applies to the given 
        /// <see cref="IMethodInvocation"/>.
        /// </summary>
        /// <param name="invocation">The invocation to evaluate the 
        /// behavior against.</param>
        bool AppliesTo(IMethodInvocation invocation);

        /// <summary>
        /// Invocation behavior for the proxy.
        /// </summary>
        /// <param name="invocation">The current method invocation.</param>
        /// <param name="getNext">Delegate to invoke the next behavior in the pipeline.</param>
        /// <returns>The result of the method invocation.</returns>
		IMethodReturn Invoke(IMethodInvocation invocation, GetNextBehavior getNext);
    }

    /// <summary>
    /// Method signature for getting the next behavior in a pipeline.
    /// </summary>
    /// <returns>The delegate to invoke the next behavior in a pipeline.</returns>
	public delegate InvokeBehavior GetNextBehavior();

    /// <summary>
    /// Method signature for invoking the next behavior in a pipeline.
    /// </summary>
    /// <param name="invocation">The current method invocation.</param>
    /// <param name="getNext">Delegate to invoke the next behavior in the pipeline.</param>
    /// <returns>The result of the method invocation.</returns>
    public delegate IMethodReturn InvokeBehavior(IMethodInvocation invocation, GetNextBehavior getNext);

    /// <summary>
    /// Method signature of <see cref="IProxyBehavior.AppliesTo"/> for use in 
    /// <see cref="ProxyBehavior.Create(InvokeBehavior, AppliesTo, string)"/> for anonymous 
    /// behaviors.
    /// </summary>
    public delegate bool AppliesTo(IMethodInvocation invocation);
}