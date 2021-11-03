import React from "react";
import { NavLink } from "react-router-dom";
import {
  HOME,
  BRAND
} from "src/constants/pages";
import Roles from "src/constants/roles";
import { useAppSelector } from "src/hooks/redux";

const SideBar = () => {
  const { account } = useAppSelector(state => state.authReducer);

  return (
    <div className="nav-left mb-5">
      <img src='/images/Logo_lk.png' alt='logo' />
      <p className="brand intro-x">Admin Dashboard</p>

      <NavLink className="navItem intro-x" exact to={HOME}>
        <button className="btnCustom">Home</button>
      </NavLink>

      {
        account?.profile.role === Roles.Admin && (
          <div className=''>
            <NavLink className="navItem intro-x" to={BRAND}>
              <button className="btnCustom">Manage Brand</button>
            </NavLink>
          </div>
        )
      }
    </div>
  );
};

export default SideBar;
