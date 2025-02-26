﻿#region copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZM Dresden)                    */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2022                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

namespace Zeiss.PiWeb.Api.Rest.Dtos.JsonConverters
{
	#region usings

	using System;
	using System.Text.Json;
	using System.Text.Json.Serialization;
	using Zeiss.PiWeb.Api.Rest.Dtos.Data;

	#endregion

	/// <summary>
	/// Specialized <see cref="JsonConverter"/> for <see cref="DataValueDto"/>-objects.
	/// </summary>
	public sealed class JsonDataValueConverter : JsonConverter<DataValueDto>
	{
		#region methods

		/// <inheritdoc />
		public override DataValueDto Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
		{
			return new DataValueDto( JsonAttributeArrayConverter.ReadAttributes( ref reader ) );
		}

		/// <inheritdoc />
		public override void Write( Utf8JsonWriter writer, DataValueDto value, JsonSerializerOptions options )
		{
			writer.WriteStartObject();
			JsonAttributeArrayConverter.WriteAttributes( writer, value.Attributes, options );
			writer.WriteEndObject();
		}

		#endregion
	}
}