import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const CarDetail = () => {
  const { id } = useParams();
  const [car, setCar] = useState(null);

  useEffect(() => {
    fetch(`http://localhost:5000/api/cars/${id}`)
      .then((res) => res.json())
      .then((data) => setCar(data));
  }, [id]);

  if (!car) return <div className="text-center mt-5">Loading...</div>;

  return (
    <div className="container mt-4">
      <h1>{car.name}</h1>
      <p><strong>Brand:</strong> {car.brand}</p>
      <p><strong>Year:</strong> {car.year}</p>
      <p><strong>Price:</strong> ${car.price}</p>
      <img src={car.imageUrl} alt={car.name} className="img-fluid" /> 
      <p className="mt-3">{car.description}</p>
    </div>
  );
};

export default CarDetail;
