import "./App.css";
import BrandByNameAndId from "./BrandByNameAndId";
import Brands from "./Brands";
import CreateBrand from "./CreateBrand";
import Products from "./products";

function App() {
  return (
    <>
      <Products />
      <Brands />
      <CreateBrand />
      <BrandByNameAndId name="Solstix" id="QnJhbmQ6MTA=" />
    </>
  );
}

export default App;
