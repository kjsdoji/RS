import React from "react";
import { Modal, } from "react-bootstrap";

import ICategory from "../../../interfaces/Category/ICategory";
import formatDateTime from "../../../utils/formatDateTime";
import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "../../../constants/Brand/BrandConstants";

type Props = {
  category: ICategory;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ category, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal">
            Detailed Category Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y'>
              <div className='col-4'>Id:</div>
              <div>{category.id}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Name:</div>
              <div>{category.name}</div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;