import { takeLatest } from 'redux-saga/effects';

import { createCategory, getCategories, updateCategory, disableCategory } from '../reducer';
import { handleCreateCategory, handleGetCategories, handleUpdateCategory, handleDisableCategory } from './handles';

export default function* CategorySagas() {
    yield takeLatest(createCategory.type, handleCreateCategory);
    yield takeLatest(getCategories.type, handleGetCategories);
    yield takeLatest(updateCategory.type, handleUpdateCategory);
    yield takeLatest(disableCategory.type, handleDisableCategory);
}
