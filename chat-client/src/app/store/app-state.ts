import { createAction, createReducer, on, props } from "@ngrx/store";
import { Message } from "../models/message";

export interface IAppState {
  messages: Message[],
  username: string
}

export const appInitialState: IAppState = {
  messages: [],
  username: ''
}

export const setMessages = createAction('[Chat] Set Messages', props<{ payload: Message[]}>());
export const addMessage = createAction('[Chat] Add Message', props<Message>());

export const userLogin = createAction('[Chat] User Login', props<{ payload: string}>());

export const loadMessages = createAction('[Chat] Load Messages');
export const loadMessagesSuccess = createAction('[Chat] [Success] Load Messages');

export const appReducer = createReducer(
  appInitialState,
  on(setMessages, (state, action) => {
    state = {
      ...state,
      messages: action.payload
    }
    return state;
  }),
  on(addMessage, (state, message) => {
    state = {
      ...state,
      messages: [...state.messages, message]
    }
    return state;
  }),
  on(userLogin, (state, action) => {
    state = {
      ...state,
      username: action.payload
    }
    return state;
  })
)
