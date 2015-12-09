using System;

namespace LauncherWFP.Data
{

    /// <summary>
    ///     Represents something that may or may not have a value.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <example>
    ///     Consider the following (mediocre) class:
    /// <c>
    /// <![CDATA[
    ///     public sealed class RedisQueue{T}
    ///     {
    ///         public Option{T} Dequeue{T}() { /* Implementation Details */ }    
    ///         public void Enqueue{T}(T value) { /* Implementation Details /* }
    ///         public RedisQueue(string connectionString, string queueName) { }
    ///     }
    /// ]]>
    ///     Assuming that the implementor of the RedisQueue{T} class did everything properly, this is how you'd consume it:
    /// <![CDATA[
    ///     var rQueue = new RedisQueue{TValue}("RedisConnectionString", "CollectionOfStrings");
    ///     var attemptToDequeue = rQueue.Dequeue();
    ///     if (attemptToDequeue.HasValue)
    ///     {
    ///         // Either of these approaches is valid
    ///         var resultOne = attemptToDequeue.Value;
    ///         var resultTwo = (TValue)attemptToDequeue;
    ///     }
    /// ]]>
    /// </c>
    /// </example>
    public struct Option<T>
    {
        private readonly T _value;

        /// <summary>
        ///     Gets whether this <see cref="Option{T}"/> has a <see cref="Value"/>.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        ///     Gets the Value (<typeparamref name="T"/>) of this <see cref="Option{T}"/>
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public T Value
        {
            get
            {
                if (!HasValue) throw new InvalidOperationException("There is no value. Please check for a value first.");
                return _value;
            }
        }

        /// <summary>
        ///     Gets an empty <see cref="Option{T}"/>.
        /// </summary>
        public static Option<T> Empty { get; } = new Option<T>(default(T), false);

        /// <summary>
        ///     The parameterless constructor has been hidden. I do not want an instance of <see cref="Option{T}"/> to be created normally.
        /// </summary>
        /// <param name="value">The initial value to populate <see cref="Option{T}"/> with</param>
        /// <param name="hasValue">Indicates whether or not <see cref="Option{T}"/> has a value that can be returned</param>
        private Option(T value, bool hasValue)
        {
            _value = value;
            HasValue = hasValue;
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Option{T}"/> with a value.
        /// </summary>
        public Option(T value) : this(value, true) { }

        /// <summary>
        ///     Converts an instance of <see cref="Option{T}"/> to its actual value.
        /// </summary>
        /// <exception cref="InvalidOperationException">If <see cref="HasValue"/> is false</exception>
        public static implicit operator T(Option<T> option)
        {
            return option.Value;
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Option{T}"/> with a value.
        /// </summary>
        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        /// <summary>
        ///     Implicitly converts the non-generic <see cref="Option"/> to <see cref="Empty"/>
        /// </summary>
        public static implicit operator Option<T>(Option option)
        {
            return Empty;
        }
    }

    /// <summary>
    ///     Non-generic class for interacting with <see cref="Option{T}"/>.
    /// </summary>
    /// <remarks>
    ///     <see cref="Option"/> can be null, so, be careful.
    /// </remarks>
    public sealed class Option
    {

        /// <summary>
        /// Represents any empty <see cref="Option"/>
        /// </summary>
        public static Option Empty { get; } = new Option();

        /// <summary>
        ///     The parameterless constructor has been hidden. I do not want an instance of <see cref="Option"/> to be created normally.
        /// </summary>
        private Option() { }

        /// <summary>
        /// Creates a new <see cref="Option{T}"/> with a value.
        /// </summary>
        /// <param name="value">Value to be passed in.</param>
        /// <returns></returns>
        public static Option<T> Create<T>(T value)
        {
            return new Option<T>(value);
        }

    }

}