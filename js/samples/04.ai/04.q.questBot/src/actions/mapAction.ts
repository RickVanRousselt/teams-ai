import { TurnContext } from "botbuilder";
import { Application, OpenAIPredictionEngine } from "botbuilder-m365";
import { ApplicationTurnState, IDataEntities, trimPromptResponse, updateDMResponse } from "../bot";
import * as responses from '../responses';
import * as prompts from '../prompts';

export function mapAction(app: Application<ApplicationTurnState>, predictionEngine: OpenAIPredictionEngine): void {
    app.ai.action('map', async (context, state, data: IDataEntities) => {
        const action = (data.action ?? '').toLowerCase();
        switch (action) {
            case 'query':
                return await queryMap(predictionEngine, context, state);
            default:
                await context.sendActivity(`[map.${action}]`);
                return true;
        }
    });
}

async function queryMap(predictionEngine: OpenAIPredictionEngine, context: TurnContext, state: ApplicationTurnState): Promise<boolean> {
    // Use the map to answer player
    let newResponse = await predictionEngine.prompt(context, state, prompts.useMap);
    if (newResponse) {
        await updateDMResponse(context, state, trimPromptResponse(newResponse).split('\n').join('<br>'));
        state.temp.value.playerAnswered = true;
    } else {
        await updateDMResponse(context, state, responses.dataError());
    }

    return false;
}