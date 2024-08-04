import React from "react";
import { gql, useQuery } from "@apollo/client";
import { useGetBrandsQuery } from "./graphql/GraphQLService";

const Brands = () => {
  const { loading, error, data } = useGetBrandsQuery({
    last: 3,
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div>
      <h2>Brands</h2>
      <ul>
        {data.brands.nodes.map((brand: any) => (
          <li key={brand.id}>
            <strong>{brand.name}</strong>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Brands;
