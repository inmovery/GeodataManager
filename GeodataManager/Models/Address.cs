using Newtonsoft.Json;

namespace GeoDataManager.Models
{
	public class Address
	{
		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("result")]
		public string Result { get; set; }

		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("country_iso_code")]
		public string CountryIsoCode { get; set; }

		[JsonProperty("federal_district")]
		public string FederalDistrict { get; set; }

		[JsonProperty("region_fias_id")]
		public string RegionFiasId { get; set; }

		[JsonProperty("region_kladr_id")]
		public string RegionKladrId { get; set; }

		[JsonProperty("region_iso_code")]
		public string RegionIsoCode { get; set; }

		[JsonProperty("region_with_type")]
		public string region_with_type { get; set; }

		[JsonProperty("region_type")]
		public string region_type { get; set; }

		[JsonProperty("region_type_full")]
		public string region_type_full { get; set; }

		[JsonProperty("region")]
		public string region { get; set; }

		[JsonProperty("area_fias_id")]
		public string area_fias_id { get; set; }

		[JsonProperty("area_kladr_id")]
		public string area_kladr_id { get; set; }

		[JsonProperty("area_with_type")]
		public string area_with_type { get; set; }

		[JsonProperty("area_type")]
		public string area_type { get; set; }

		[JsonProperty("area_type_full")]
		public string area_type_full { get; set; }

		[JsonProperty("area")]
		public string area { get; set; }

		[JsonProperty("sub_area_fias_id")]
		public string sub_area_fias_id { get; set; }

		[JsonProperty("sub_area_kladr_id")]
		public string sub_area_kladr_id { get; set; }

		[JsonProperty("sub_area_with_type")]
		public string sub_area_with_type { get; set; }

		[JsonProperty("sub_area_type")]
		public string sub_area_type { get; set; }

		[JsonProperty("sub_area_type_full")]
		public string sub_area_type_full { get; set; }

		[JsonProperty("sub_area")]
		public string sub_area { get; set; }

		[JsonProperty("city_fias_id")]
		public string city_fias_id { get; set; }

		[JsonProperty("city_kladr_id")]
		public string city_kladr_id { get; set; }

		[JsonProperty("city_with_type")]
		public string city_with_type { get; set; }

		[JsonProperty("city_type")]
		public string city_type { get; set; }

		[JsonProperty("city_type_full")]
		public string city_type_full { get; set; }

		[JsonProperty("city")]
		public string city { get; set; }

		[JsonProperty("city_area")]
		public string city_area { get; set; }

		[JsonProperty("city_district_fias_id")]
		public string city_district_fias_id { get; set; }

		[JsonProperty("city_district_kladr_id")]
		public string city_district_kladr_id { get; set; }

		[JsonProperty("city_district_with_type")]
		public string city_district_with_type { get; set; }

		[JsonProperty("city_district_type")]
		public string city_district_type { get; set; }

		[JsonProperty("city_district_type_full")]
		public string city_district_type_full { get; set; }

		[JsonProperty("city_district")]
		public string city_district { get; set; }

		[JsonProperty("settlement_fias_id")]
		public string settlement_fias_id { get; set; }

		[JsonProperty("settlement_kladr_id")]
		public string settlement_kladr_id { get; set; }

		[JsonProperty("settlement_with_type")]
		public string settlement_with_type { get; set; }

		[JsonProperty("settlement_type")]
		public string settlement_type { get; set; }

		[JsonProperty("settlement_type_full")]
		public string settlement_type_full { get; set; }

		[JsonProperty("settlement")]
		public string settlement { get; set; }

		[JsonProperty("street_fias_id")]
		public string street_fias_id { get; set; }

		[JsonProperty("street_kladr_id")]
		public string street_kladr_id { get; set; }

		[JsonProperty("street_with_type")]
		public string street_with_type { get; set; }

		[JsonProperty("street_type")]
		public string street_type { get; set; }

		[JsonProperty("street_type_full")]
		public string street_type_full { get; set; }

		[JsonProperty("street")]
		public string street { get; set; }

		[JsonProperty("house_fias_id")]
		public string house_fias_id { get; set; }

		[JsonProperty("house_kladr_id")]
		public string house_kladr_id { get; set; }

		[JsonProperty("house_cadnum")]
		public string house_cadnum { get; set; }

		[JsonProperty("house_with_type")]
		public string house_with_type { get; set; }

		[JsonProperty("house_type")]
		public string house_type { get; set; }

		[JsonProperty("house_type_full")]
		public string house_type_full { get; set; }

		[JsonProperty("house")]
		public string house { get; set; }

		[JsonProperty("block_type")]
		public string block_type { get; set; }

		[JsonProperty("block_type_full")]
		public string block_type_full { get; set; }

		[JsonProperty("block")]
		public string block { get; set; }

		[JsonProperty("entrance")]
		public string entrance { get; set; }

		[JsonProperty("floor")]
		public string floor { get; set; }

		[JsonProperty("flat_fias_id")]
		public string flat_fias_id { get; set; }

		[JsonProperty("flat_cadnum")]
		public string flat_cadnum { get; set; }

		[JsonProperty("flat_type")]
		public string flat_type { get; set; }

		[JsonProperty("flat_type_full")]
		public string flat_type_full { get; set; }

		[JsonProperty("flat")]
		public string flat { get; set; }

		[JsonProperty("flat_area")]
		public string flat_area { get; set; }

		[JsonProperty("square_meter_price")]
		public string square_meter_price { get; set; }

		[JsonProperty("flat_price")]
		public string flat_price { get; set; }

		[JsonProperty("postal_box")]
		public string postal_box { get; set; }

		[JsonProperty("fias_id")]
		public string fias_id { get; set; }

		[JsonProperty("fias_code")]
		public string fias_code { get; set; }

		[JsonProperty("fias_level")]
		public string fias_level { get; set; }

		[JsonProperty("fias_actuality_state")]
		public string fias_actuality_state { get; set; }

		[JsonProperty("kladr_id")]
		public string kladr_id { get; set; }

		[JsonProperty("geoname_id")]
		public string geoname_id { get; set; }

		[JsonProperty("capital_marker")]
		public string capital_marker { get; set; }

		[JsonProperty("okato")]
		public string okato { get; set; }

		[JsonProperty("oktmo")]
		public string oktmo { get; set; }

		[JsonProperty("tax_office")]
		public string tax_office { get; set; }

		[JsonProperty("tax_office_legal")]
		public string tax_office_legal { get; set; }

		[JsonProperty("timezone")]
		public string timezone { get; set; }

		[JsonProperty("geo_lat")]
		public string geo_lat { get; set; }

		[JsonProperty("geo_lon")]
		public string geo_lon { get; set; }

		[JsonProperty("beltway_hit")]
		public string beltway_hit { get; set; }

		[JsonProperty("beltway_distance")]
		public string BeltwayDistance { get; set; }

		[JsonProperty("qc_geo")]
		public string QCGeo { get; set; }

		[JsonProperty("qc_complete")]
		public string QCComplete { get; set; }

		[JsonProperty("qc_house")]
		public string QCHouse { get; set; }

		[JsonProperty("qc")]
		public string QC { get; set; }

		[JsonProperty("unparsed_parts")]
		public string UnparsedParts { get; set; }

		[JsonProperty("history_values")]
		public List<string> HistoryValues { get; set; }
	}
}
