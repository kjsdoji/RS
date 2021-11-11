import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
// import ButtonIcon from "src/components/ButtonIcon";
import ButtonIcon from "../../../components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "../../../components/Table";
import IColumnOption from "../../../interfaces/IColumnOption";
import IPagedModel from "../../../interfaces/IPagedModel";
import ICategory from "../../../interfaces/Category/ICategory";
import formatDateTime from "../../../utils/formatDateTime";
import Info from "../Info";
import { EDIT_CATEGORY_ID } from "../../../constants/pages";
import ConfirmModal from "../../../components/ConfirmModal";
import { useAppDispatch } from "../../../hooks/redux";
import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "../../../constants/Brand/BrandConstants";
import { disableCategory } from "../reducer";

const columns: IColumnOption[] = [
  { columnName: "id", columnValue: "Id" },
  { columnName: "name", columnValue: "Name" }
];

type Props = {
  categories: IPagedModel<ICategory> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
};

const CategoryTable: React.FC<Props> = ({
  categories,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [showDetail, setShowDetail] = useState(false);
  const [categoryDetail, setCategoryDetail] = useState(null as ICategory | null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id: number) => {
    const category = categories?.items.find((item) => item.id === id);

    if (category) {
      setCategoryDetail(category);
      setShowDetail(true);
    }
  };

  const getBrandTypeName = (id: number) => {
    return id == LuxuryBrandType ? LuxyryBrandTypeLabel : NormalBrandTypeLabel;
  }

  const handleShowDisable = async (id: number) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this category?',
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      id: 0,
      title: '',
      message: '',
      isDisable: true,
    });
  };

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      handleCloseDisable();
      fetchData();
      NotificationManager.success(
        `Remove Category Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable category',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = () => {
    dispatch(disableCategory({
      handleResult,
      categoryId: disableState.id,
    }));
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id: number) => {
    history.push(EDIT_CATEGORY_ID(id));
  };

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: categories?.currentPage,
          totalPage: categories?.totalPages,
          handleChange: handlePage,
        }}
      >
        {categories?.items.map((data, index) => (
          <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
            <td>{data.id}</td>
            <td>{data.name}</td>

            <td className="d-flex">
              <ButtonIcon onClick={() => handleEdit(data.id)}>
                <PencilFill className="text-black" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleShowDisable(data.id)}>
                <XCircle className="text-danger mx-2" />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      {categoryDetail && showDetail && (
        <Info category={categoryDetail} handleClose={handleCloseDetail} />
      )}
      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>
          <div className="text-center">
            {disableState.message}
          </div>
          {
            disableState.isDisable && (
              <div className="text-center mt-3">
                <button
                  className="btn btn-danger mr-3"
                  onClick={handleConfirmDisable}
                  type="button"
                >
                  Disable
            </button>

                <button
                  className="btn btn-outline-secondary"
                  onClick={handleCloseDisable}
                  type="button"
                >
                  Cancel
            </button>
              </div>
            )
          }
        </div>
      </ConfirmModal>
    </>
  );
};

export default CategoryTable;
