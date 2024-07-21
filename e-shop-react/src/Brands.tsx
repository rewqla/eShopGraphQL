import React from "react";
import { gql, useQuery } from "@apollo/client";

const GET_BRANDS = gql`
  query GetBrands($last: Int) {
    brands(last: $last) {
      nodes {
        id
        name
      }
    }
  }
`;

const Brands = () => {
  const { loading, error, data } = useQuery(GET_BRANDS, {
    variables: {
      last: 3,
    },
  });

  console.log(data);
  console.log(error);

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
