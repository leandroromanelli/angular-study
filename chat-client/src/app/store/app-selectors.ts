import { createFeatureSelector, createSelector } from "@ngrx/store";
import { IAppState } from "./app-state";

export const appSelector = createFeatureSelector<IAppState>('app')

export const selectUser = createSelector(
  appSelector,
  (state) => {
    return state.username
  }
)

export const selectMessages = createSelector(
  appSelector,
  (state) => {
    return state.messages
  }
)
