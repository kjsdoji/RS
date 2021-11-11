import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";

import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import IBrandUserModel from "../../../interfaces/Brand/IQueryBrandModel";
import { getCategories } from "../reducer";
import { Link } from "react-router-dom";
import CategoryTable from "./CategoryTable";
import IQueryCategoryModel from "../../../interfaces/Category/IQueryCategoryModel";
import ISelectOption from "../../../interfaces/ISelectOption";
import { FilterBrandTypeOptions } from "../../../constants/selectOptions";
import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_BRAND_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../../constants/paging"

const ListCategory = () => {
  const dispatch = useAppDispatch();
  const { categories, loading } = useAppSelector((state) => state.categoryReducer);

  const [query, setQuery] = useState({
    page: categories?.currentPage ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_BRAND_SORT_COLUMN_NAME
  } as IQueryCategoryModel);

  const [search, setSearch] = useState("");

  const [selectedType, setSelectedType] = useState([
    { id: 1, label: "All", value: 0 },
  ] as ISelectOption[]);

  const handleType = (selected: ISelectOption[]) => {
    if (selected.length === 0) {
      setQuery({
        ...query,
        types: [],
      });

      setSelectedType([FilterBrandTypeOptions[0]]);
      return;
    }

    const selectedAll = selected.find((item) => item.id === 1);

    setSelectedType((prevSelected) => {
      if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
        setQuery({
          ...query,
          types: [],
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id !== 1);
      const types = newSelected.map((item) => item.value as number);

      setQuery({
        ...query,
        types,
      });

      return newSelected;
    });
  };

  const handleChangeSearch = (e) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      search,
    });
  };

  const handleSort = (sortColumn: string) => {
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
    });
  };

  const fetchData = () => {
    dispatch(getCategories(query));
  }

  useEffect(() => {
    fetchData();
  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Category List</div>

      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
          </div>

          <div className="d-flex align-items-center w-ld ml-auto">
            <div className="input-group">
              <input
                onChange={handleChangeSearch}
                value={search}
                type="text"
                className="form-control"
              />
              <span onClick={handleSearch} className="border p-2 pointer">
                <Search />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <Link to="/category/create" type="button" className="btn btn-danger">
              Create New Category 
            </Link>
          </div>
        </div>

        <CategoryTable
          categories={categories}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          fetchData={fetchData}
        />
      </div>
    </>
  );
};

export default ListCategory;
