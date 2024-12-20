# Assistants Planner

<small>**Navigation**</small>

- [00.OVERVIEW](./README.md)
- [Action Planner](./ACTION-PLANNER.md)
- [Actions](./ACTIONS.md)
- [AI System](./AI-SYSTEM.md)
- [Application class](./APPLICATION.md)
- [Augmentations](./AUGMENTATIONS.md)
- [Data Sources](./DATA-SOURCES.md)
- [Moderator](./MODERATOR.md)
- [Planner](./PLANNER.md)
- [Powered by AI](./POWERED-BY-AI.md)
- [Prompts](./PROMPTS.md)
- [Streaming](./STREAMING.md)
- [Turns](./TURNS.md)
- [User Authentication](./USER-AUTH.md)
- [**Assistants Planner**](./ASSISTANTS-PLANNER.md)
---

> As of 2024-08-26 The latest features of Assistants Planner is only available in the .NET SDK. Javascript and Python SDKs will be brought to parity in the near future.

The [Assistants API](https://platform.openai.com/docs/assistants/overview) allows you to build AI assistants within your own applications. An Assistant has instructions and can leverage models, tools, and files to respond to user queries. The Assistants API currently supports three types of tools: Code Interpreter, File Search, and Function calling.

To learn more about it you can read the [Assistants API Overview](https://platform.openai.com/docs/assistants/overview) and try it out in the [OpenAI Assistants Playground](https://platform.openai.com/playground/assistants). 

The Assistants Planner connects your Assistant to the Teams AI library which allows you to deploy it as a chat bot in Microsoft Teams.

## When would you use the Assistants Planner?
If you want to connect an OpenAI/Azure OpenAI Assistant to Microsoft Teams.  

## Samples

The best way to try the Assistants Planner is to setup and run one of the samples:

* `Math Tutor Bot`
* `Food Ordering Bot`

From the [samples catalogue](https://github.com/microsoft/teams-ai/blob/main/getting-started/SAMPLES.md#ai-apps).

## High Level Features
In this section terms like `Assistant`, `Thread`, `Message`, `Run` will refer to Assistants API concepts.

* `beta-v2` API is used by default.
* A Thread is created for every single conversation.
* Supports both OpenAI and Azure OpenAI Assistants API.
* Authentication using API Keys and Microsoft Entra ID managed identity (Azure OpenAI only)  


### File Search
If the Assistant has the File Search tool enabled then the following features will be enabled in the Assistants Planner:

* Files uploaded by the user will be stored in the Thread's vector store. The uploaded file must have a file name and file extension.
* If the File Search tool is used in the Run and `file_search` text annotations are added to the generated Message, then it will be mapped to the Activity that gets sent to Microsoft Teams, utilizing the appropriate UI/UX features. 

### Code Interpretor
If the Assistant has the Code Interpretor tool enabled then the following features will be enabled in the Assistants Planner:

* Downloading files generated by the Code Interpretor tool. Currently only image files (`jpg`, `jpeg`, `png`, `gif`) will be attached to the activity sent to Microsoft Teams.

### Function Calling
If the Assistant has the File Search tool enabled then the following features will be enabled in the Assistants Planner:

* The predicted functions will invoke the corresponding `Actions` that are registered to the `AI` module. It is identified using the Action name, and the predicted arguments are also passed as an argument to the action. The corresponding outputs are then passed back to the Assistant to continue the Run.
