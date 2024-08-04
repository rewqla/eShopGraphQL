import React from "react";
import { gql, useQuery } from "@apollo/client";
import { useGetBrandByNameAndIdQuery } from "./graphql/GraphQLService";

declare interface BrandByNameAndIdProps {
  name: string;
  id: string;
}

const BrandByNameAndId: React.FC<BrandByNameAndIdProps> = ({ name, id }) => {
  const { loading, error, data } = useGetBrandByNameAndIdQuery({
    name,
    id,
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
