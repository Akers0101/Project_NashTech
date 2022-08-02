import { makeStyles } from "@mui/styles";
import { DataGrid, GridToolbarContainer, GridToolbarExport } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";
import CustomNoRowsOverlay from "../../Components/NoRowsOverlay/CustomNoRowsOverlay";
import Custompagination from "../../Components/Pagination/CustomPagination";

const styles = makeStyles({
  table: {
    // boxShadow: "2px 2px 5px -1px rgba(0,0,0,0.75)",
    width: "cover",
    margin: "25px 50px 0 50px",
  },
});

function CustomToolbar() {
  return (
    <GridToolbarContainer>
      <GridToolbarExport 
      printOptions={{
        hideFooter: true,
        hideToolbar: true,
      }}
      />
    </GridToolbarContainer>
  );
}
const ReportDatatable = () => {
  const token = localStorage.getItem("token");
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    loadData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const loadData = async () => {
    setLoading(true);

    const response = await axios({
      method: "GET",
      url: `${process.env.REACT_APP_Backend_URI}/Report`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    setGridData(response.data);
    setLoading(false);
  };
 
  
  const classes = styles();
  const columns = [
    {
      headerName: "Category",
      field: "categoryName",
      width: 300,
    },
    {
      headerName: "Total",
      field: "total",
      width: 200,
    },
    {
      headerName: "Assigned",
      field: "assigned",
      width: 200,
    },
    {
      headerName: "Available",
      field: "available",
      width: 200,
    },
    {
      headerName: "Not Available",
      field: "notAvailable",
      width: 200,
    },
    {
      headerName: "Waiting For Recycling",
      field: "waitingForRecycling",
      width: 200,
    }
  ];

  

  return (
    <div>
      
      <div className={classes.table}>
        <DataGrid
         sortingOrder={['desc', 'asc']}
          pagination
          autoHeight
          {...gridData}
          columns={columns}
          rows={gridData}
          pageSize={10}
          rowsPerPageOptions={[10]}
          loading={loading}
          components={{
            Pagination: Custompagination,
            NoRowsOverlay: CustomNoRowsOverlay,
            Toolbar: CustomToolbar,
          }}
          
          getRowId={(row) => row.categoryName}
        />
      </div>
    </div>
  );
};

export default ReportDatatable;
