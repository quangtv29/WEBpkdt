// import React, { useState, useEffect } from 'react';
// import axios from 'axios';
import React from "react";
// import { Link } from "react-router-dom";
import Marquee from "react-fast-marquee";
import BlogCard from "../components/BlogCard";
import ProductCard from "../components/ProductCard";
// import SpecialProduct from "../components/SpecialProduct";
import Container from "../components/Container";
// import { services } from "../ultils/Data";
import meo from "../assets/images/meo.png";
// import mainbanner from "../assets/images/main-banner-1.jpg";
// import mainbanner2 from "../assets/images/main-banner.jpg";
// import mainbanner3 from "../assets/images/main-banner-1.jpg";
import beautiful from "../assets/images/beautiful.png";
// import famous2 from "../assets/images/famous-2.webp";
// import famous3 from "../assets/images/famous-3.webp";
// import famous4 from "../assets/images/famous-4.webp";
import brand from "../assets/images/brand-01.png";
import brand2 from "../assets/images/brand-02.png";
import brand3 from "../assets/images/brand-03.png";
import brand4 from "../assets/images/brand-04.png";
import brand5 from "../assets/images/brand-05.png";
import brand6 from "../assets/images/brand-06.png";
import brand7 from "../assets/images/brand-07.png";
import brand8 from "../assets/images/brand-08.png";
import { useEffect, useState } from "react";
import axios from "axios";
const Home = () => {
  const [data, setData] = useState([]);
  useEffect(() => {
    axios.get("https://localhost:7295/api/Blog/getBlog").then((res) => {
      setData(res.data);
    });
  }, []);
  const [type, setType] = useState([]);
  useEffect(() => {
    const fetchLoaiSanPham = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7295/api/ProductType/GetAll"
        );
        setType(response.data.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchLoaiSanPham();
  }, []);
  const [seller, setSeller] = useState([]);
  useEffect(() => {
    axios
      .post("https://localhost:7295/api/Product/getTopSeller", {
        pageNumber: 1,
        pageSize: 4,
      })
      .then((res) => {
        setSeller(res.data);
        console.log(res.data);
      });
  }, []);

  return (
    <>
      <Container class1="home-wrapper-1 py-5">
        <div className="row">
          <div className="col-6">
            <div className="main-banner position-relative ">
              <img src={meo} className="rounded-3" alt="main banner" />
            </div>
          </div>
          <div className="col-6">
            <div className="main-banner position-relative ">
              <img
                src={beautiful}
                className="img-fluid rounded-3"
                alt="main banner"
              />
            </div>
          </div>
        </div>
      </Container>
      {/* <Container class1="home-wrapper-2 py-5">
        <div className="row">
          <div className="col-12">
            <div className="servies d-flex align-items-center justify-content-between">
              {services?.map((i, j) => {
                return (
                  <div className="d-flex align-items-center gap-15" key={j}>
                    <img src={i.image} alt="services" />
                    <div>
                      <h6>{i.title}</h6>
                      <p className="mb-0">{i.tagline}</p>
                    </div>
                  </div>
                );
              })}
            </div>
          </div>
        </div>
      </Container> */}
      {/* <Container class1="home-wrapper-2 py-5">
        <div className="row">
          <div className="col-12">
            <div className="categories d-flex justify-content-between flex-wrap align-items-center">
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Music & Gaming</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Cameras</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Smart Tv</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Smart Watches</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Music & Gaming</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Cameras</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Smart Tv</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
              <div className="d-flex gap align-items-center">
                <div>
                  <h6>Smart Watches</h6>
                  <p>10 Items</p>
                </div>
                <img src={camera} alt="camera" />
              </div>
            </div>
          </div>
        </div>
      </Container> */}
      {/* <Container class1="featured-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading">Featured Collection</h3>
          </div>
        </div>
      </Container> */}

      {/* <Container class1="famous-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-3">
            <div className="famous-card position-relative">
              <img src={famous} className="img-fluid" alt="famous" />
              <div className="famous-content position-absolute">
                <h5>Big Screen</h5>
                <h6>Smart Watch Series 7</h6>
                <p>From $399or $16.62/mo. for 24 mo.*</p>
              </div>
            </div>
          </div>
          <div className="col-3">
            <div className="famous-card position-relative">
              <img src={famous2} className="img-fluid" alt="famous" />
              <div className="famous-content position-absolute">
                <h5 className="text-dark">Studio Display</h5>
                <h6 className="text-dark">600 nits of brightness.</h6>
                <p className="text-dark">27-inch 5K Retina display</p>
              </div>
            </div>
          </div>
          <div className="col-3">
            <div className="famous-card position-relative">
              <img src={famous3} className="img-fluid" alt="famous" />
              <div className="famous-content position-absolute">
                <h5 className="text-dark">smartphones</h5>
                <h6 className="text-dark">Smartphone 13 Pro.</h6>
                <p className="text-dark">
                  Now in Green. From $999.00 or $41.62/mo. for 24 mo. Footnote*
                </p>
              </div>
            </div>
          </div>
          <div className="col-3">
            <div className="famous-card position-relative">
              <img src={famous4} className="img-fluid" alt="famous" />
              <div className="famous-content position-absolute">
                <h5 className="text-dark">home speakers</h5>
                <h6 className="text-dark">Room-filling sound.</h6>
                <p className="text-dark">
                  From $699 or $116.58/mo. for 12 mo.*
                </p>
              </div>
            </div>
          </div>
        </div>
      </Container> */}

      {/* <Container class1="special-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading">Sản phẩm đặc biệt</h3>
          </div>
        </div>
        <div className="row">
          <SpecialProduct />
          <SpecialProduct />
          <SpecialProduct />
          <SpecialProduct />
        </div>
      </Container> */}
      <Container class1="popular-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading text-center">Sản phẩm bán chạy</h3>
          </div>
        </div>
        <div className="products-list ">
          <div className="d-flex  flex-wrap">
            {seller && <ProductCard grid={4} product={seller} />}
          </div>
        </div>
      </Container>
      <Container class1="marque-wrapper home-wrapper-2 py-5">
        <div className="row">
          <div className="col-12">
            <div className="marquee-inner-wrapper card-wrapper">
              <Marquee className="d-flex">
                <div className="mx-4 w-25">
                  <img src={brand} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand2} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand3} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand4} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand5} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand6} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand7} alt="brand" />
                </div>
                <div className="mx-4 w-25">
                  <img src={brand8} alt="brand" />
                </div>
              </Marquee>
            </div>
          </div>
        </div>
      </Container>

      <Container class1="blog-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading">Blogs mới nhất</h3>
          </div>
        </div>
        <div className="row">
          {data?.map((item) => (
            <div key={item?.id} className="col-3 mb-3">
              {data && <BlogCard item={item} />}
            </div>
          ))}
        </div>
      </Container>
    </>
  );
};

export default Home;
