import { createAction, createReducer, on, props } from "@ngrx/store";
import { Message } from "../models/message";
import { DummyData } from "../models/dummy-data";

export interface IAppState {
  messages: Message[],
  username: string,
  dummyData: DummyData[]
}

export const appInitialState: IAppState = {
  messages: [],
  username: '',
  dummyData: []
}

export const setMessages = createAction('[Chat] Set Messages', props<{ payload: Message[]}>());
export const addMessage = createAction('[Chat] Add Message', props<Message>());

export const userLogin = createAction('[Chat] User Login', props<{ payload: string}>());

export const setDummy = createAction('[Chat] Set Dummy', props<{ payload: DummyData[]}>());
export const loadDummy = createAction('[Chat] Load Dummy');
export const loadDummySuccess = createAction('[Chat] [Success] Load Dummy');

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
  }),
  on(setDummy, (state, action) => {
    state = {
      ...state,
      dummyData: action.payload
    }
    return state;
  })
)
