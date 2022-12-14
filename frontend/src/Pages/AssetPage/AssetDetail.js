import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Typography from "@mui/material/Typography";
import { makeStyles } from "@mui/styles";
import axios from "axios";
import Popupclose from "../../Components/Modal/Popupclose";
import moment from "moment";

const styles = makeStyles({
  wrapper: {
    width: "65%",
    margin: "auto",
    textAlign: "center",
  },
  bigSpace: {
    marginTop: "5rem",
  },
  littleSpace: {
    marginTop: "2.5rem",
    marginBottom: "2.5rem",
  },
});
export default function AssetDetail() {
  const token = localStorage.getItem("token");
  const { id } = useParams();
  const [history, setHistory] = useState([]);
  const [item, setItem] = useState({});
  const [openPopup, setOpenPopup] = useState(true);
  useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Assignment/Historicals?assetId=${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
    }
    )
      .then(function (response) {
        setHistory(response.data);
      }, [])
      .catch((error) => {
        console.log(error);
      });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Asset/${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
    }
    )
      .then(function (response) {
        setItem(response.data);
      }, [])
      .catch((error) => {
        console.log(error);
      });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

    useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Asset/${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
    }
    )
      .then(function (response) {
        setItem(response.data);
      }, [])
      .catch((error) => {
        console.log(error);
      });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);


  const classes = styles();
  return (
    <div>
      <div className={classes.wrapper}>
        <Popupclose
          title="Asset Detail"
          openPopup={openPopup}
          setOpenPopup={setOpenPopup}
        >
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            Asset Code: <span></span>
            {item.assetCode}
          </Typography>
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            Asset Name: <span></span>
            {item.assetName}
          </Typography>
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            Specification: <span></span>
            {item.specification}
          </Typography>
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            Assigned Date: <span></span>
            {moment(item.installedDate).format('DD/MM/YYYY')}
          </Typography>
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            State: <span></span>
            {item.assetState}
          </Typography>
          <Typography variant="h6" align="left" sx={{ margin: 1 }}>
            Assigment History: 
            <span></span>
             {history.map((item) => (
                    <li >{item.historical}</li>
                  ))}

          </Typography>
        </Popupclose>
      </div>
    </div>
  );
}
