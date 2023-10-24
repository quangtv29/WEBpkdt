import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Select from 'react-select';
import { useForm } from 'react-hook-form';
const AddressForm = (props) => {
  const { register, handleSubmit, watch, setValue } = useForm({});
  const [provinces, setProvinces] = useState([]);
  const [districts, setDistricts] = useState([]);
  const [wards, setWards] = useState([]);
  const [selectedProvince, setSelectedProvince] = useState(null);
  const [selectedDistrict, setSelectedDistrict] = useState(null);

  useEffect(() => {
    const fetchProvinces = async () => {
      try {
        const response = await axios.get(
          'https://vapi.vnappmob.com/api/province/'
        );
        const data = response.data.results.map((province) => ({
          label: province.province_name,
          value: province.province_id,
        }));
        setProvinces(data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchProvinces();
  }, []);

  useEffect(() => {
    const fetchDistricts = async () => {
      if (selectedProvince) {
        try {
          const response = await axios.get(
            `https://vapi.vnappmob.com/api/province/district/${selectedProvince.value}`
          );
          const data = response.data.results.map((district) => ({
            label: district.district_name,
            value: district.district_id,
          }));
          setDistricts(data);
        } catch (error) {
          console.log(error);
        }
      }
    };
    fetchDistricts();
  }, [selectedProvince]);

  useEffect(() => {
    const fetchWards = async () => {
      if (selectedDistrict) {
        try {
          const response = await axios.get(
            `https://vapi.vnappmob.com/api/province/ward/${selectedDistrict.value}`
          );
          const data = response.data.results.map((ward) => ({
            label: ward.ward_name,
            value: ward.ward_id,
          }));
          setWards(data);
        } catch (error) {
          console.log(error);
        }
      }
    };
    fetchWards();
  }, [selectedDistrict]);

  useEffect(() => {
    props.onChange({
      province: selectedProvince,
      district: selectedDistrict,
      ward: watch('ward'),
    });
  }, [selectedProvince, selectedDistrict, watch, props]);

  return (
    <div style={{ display: 'flex' }}>
      <Select
        {...register('province')}
        options={provinces}
        placeholder="Chọn Tỉnh/Thành phố"
        onChange={(selectedOption) => {
          setSelectedProvince(selectedOption);
          setSelectedDistrict(null);
          setWards([]);
          setValue('district', null);
        }}
        value={selectedProvince}
      />
      <Select
        {...register('district')}
        options={districts}
        placeholder="Chọn Quận/Huyện"
        onChange={(selectedOption) => {
          setSelectedDistrict(selectedOption);
          setWards([]);
          setValue('ward', null);
        }}
        value={selectedDistrict}
        isDisabled={!selectedProvince}
      />
      <Select
        {...register('ward')}
        options={wards}
        placeholder="Chọn Phường/Xã"
        onChange={(selectedOption) => {
          setValue('ward', selectedOption);
        }}
        value={watch('ward')}
        isDisabled={!selectedDistrict}
      />
    </div>
  );
};

export default AddressForm;
