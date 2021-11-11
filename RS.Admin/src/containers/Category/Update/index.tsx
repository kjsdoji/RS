import React, { useEffect, useState } from 'react'
import { Redirect, useParams } from 'react-router';

import { NOTFOUND } from '../../../constants/pages';
import { useAppSelector } from '../../../hooks/redux';
import ICategoryForm from '../../../interfaces/Category/ICategoryForm';
import CategoryForm from '../CategoryForm';

const UpdateCategoryContainer = () => {
  const { categories } = useAppSelector(state => state.categoryReducer);
  
  const [category, setCategory] = useState(undefined as ICategoryForm | undefined);

  const { id } = useParams<{ id: string }>();
  
  const existCategory = categories?.items.find(item => item.id === Number(id));

  useEffect(() => {

    if (existCategory) {
      setCategory({
        id: existCategory.id,
        name: existCategory.name
      });
    }
  }, [existCategory]);

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Update Category {existCategory?.name}
      </div>

      <div className='row'>
        {
          category && (<CategoryForm
            initialCategoryForm={category}
  
          />)
        }
      </div>
    </div>
  )
};

export default UpdateCategoryContainer;
