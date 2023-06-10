import React, { useMemo, useState, useEffect } from 'react';
import { MaterialReactTable } from 'material-react-table';
import { httpService } from './Services/httpService';
import { useNavigate } from "react-router-dom";

const PolicyDetails = () => {
  const [tableData, setTableData] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    const policyDetails = async () => {
      var data = await httpService.GetPolicyDetails();
      setTableData(data);
    }
    policyDetails();
  }, []);

  const columns = useMemo(
    () => [
      //column definitions...
      {
        accessorKey: 'policyId',
        header: 'PolicyId',
        enableEditing: false
      },
      {
        accessorKey: 'dateOfPurchase',
        header: 'DateOfPurchase',
        enableEditing: false
      },

      {
        accessorKey: 'customerId',
        header: 'CustomerId',
      },
      {
        accessorKey: 'fuel',
        header: 'Fuel',
      },
      {
        accessorKey: 'vehicleSegment',
        header: 'VehicleSegment',
      },
      {
        accessorKey: 'premium',
        header: 'Premium',
      },
      {
        accessorKey: 'customerGender',
        header: 'Gender',
      },
      {
        accessorKey: 'customerIncomeGroup',
        header: 'IncomeGroup',
      },
      {
        accessorKey: 'customerRegion',
        header: 'Region',
      },
      {
        accessorKey: 'customerMaritalStatus',
        header: 'CustomerMaritalStatus',
        Cell: ({ cell }) => <span>{cell.getValue()? "True" : "False"}</span>
      },
      {
        accessorKey: 'bodilyInjury',
        header: 'BodilyInjury',
        Cell: ({ cell }) => <span>{cell.getValue()? "True" : "False"}</span>
      }
    ],
    [],
  );



  const handleSaveRow = async ({ exitEditingMode, row, values }) => {

    await httpService.UpdatePolicyDetails(values);
    tableData[row.index] = values;
    setTableData([...tableData]);
    exitEditingMode();
  };

  const handleChange = (e) => {

  }
  return (
    <div>
      <a style={{float:'right'}} onClick={()=>{navigate('/Report')}}>Report</a><br></br>
      <MaterialReactTable
        columns={columns}
        data={tableData}
        editingMode="modal"
        enableEditing
        onEditingRowSave={handleSaveRow}
      />
    </div >
  );
};

export default PolicyDetails;