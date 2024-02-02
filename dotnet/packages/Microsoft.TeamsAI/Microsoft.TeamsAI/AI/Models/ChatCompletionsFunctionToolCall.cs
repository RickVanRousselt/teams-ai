﻿using Microsoft.Teams.AI.Utilities;

namespace Microsoft.Teams.AI.AI.Models
{
    /// <summary>
    /// Represents a function tool call in a chat message.
    /// </summary>
    public class ChatCompletionsFunctionToolCall : ChatCompletionsToolCall
    {
        /// <summary>
        /// The name of the function that is called by the tool.
        /// </summary>
        public string Name
        {
            get => Function.Name;
            set => Function.Name = value;
        }

        /// <summary>
        /// The arguments to call the function with, as generated by the model in JSON format.
        /// Note that the model does not always generate valid JSON, and may hallucinate
        /// parameters not defined by your function schema. Validate the arguments in your
        /// code before calling your function.
        /// </summary>
        public string Arguments
        {
            get => Function.Arguments;
            set => Function.Arguments = value;
        }

        internal FunctionCall Function { get; set; }

        /// <summary>
        /// Initializes a new instance of ChatCompletionsFunctionToolCall.
        /// </summary>
        /// <param name="id">Id of the function tool call.</param>
        /// <param name="name">The name of the function that is called by the tool.</param>
        /// <param name="arguments">The arguments to the function that is called by the tool.</param>
        public ChatCompletionsFunctionToolCall(string id, string name, string arguments) : base(ToolType.Function, id)
        {
            Verify.ParamNotNull(name);
            Verify.ParamNotNull(arguments);
            Verify.ParamNotNull(id);
            Function = new FunctionCall(name, arguments);
        }
    }
}