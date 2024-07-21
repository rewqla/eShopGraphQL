import React from "react";
import { gql, useQuery } from "@apollo/client";

const GET_BRAND_BY_NAME_AND_ID = gql`
  query GetBrandByNameAndId($name: String!, $id: ID!) {
    brandByName(name: $name) {
      name
      id
    }
    brandById(id: $id) {
      name
    }
  }
`;

declare interface BrandByNameAndIdProps {
  name: string;
  id: string;
}

const BrandByNameAndId: React.FC<BrandByNameAndIdProps> = ({ name, id }) => {
  const { loading, error, data } = useQuery(GET_BRAND_BY_NAME_AND_ID, {
    variables: { name, id },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <div>
      <h2>Brand Information</h2>
      <div>
        <h3>Brand By Name</h3>
        {data.brandByName ? (
          <div>
            <p>ID: {data.brandByName.id}</p>
            <p>Name: {data.brandByName.name}</p>
          </div>
        ) : (
          <p>No brand found with name {name}</p>
        )}
      </div>
      <div>
        <h3>Brand By ID</h3>
        {data.brandById ? (
          <div>
            <p>Name: {data.brandById.name}</p>
          </div>
        ) : (
          <p>No brand found with ID {id}</p>
        )}
      </div>
    </div>
  );
};

export default BrandByNameAndId;
