import { createFeatureSelector, createSelector } from "@ngrx/store";
import { IAppState } from "./app-state";

export const appSelector = createFeatureSelector<IAppState>('app')

export const selectMessages = createSelector(
  appSelector,
  (state) => {
    return state.messages
  }
)

export const selectDummies = createSelector(
  appSelector,
  (state) => {
    return state.dummyData
  }
)
export const selectSortedDummies = createSelector(
  selectDummies,
  (dummies) => {
    return [...dummies].sort((a, b) => new Date(a.updatedDateTime).getTime() - new Date(b.updatedDateTime).getTime())
  }
)

export const selectDummy = createSelector(
  selectSortedDummies,
  (dummies) => {
    return [...new Map(dummies.map(item => [item['emailId'], item]) ).values()]
  }
)
