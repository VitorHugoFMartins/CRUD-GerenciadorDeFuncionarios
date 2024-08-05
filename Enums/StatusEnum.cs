﻿using System.Text.Json.Serialization;

namespace GerenciadorDeFuncionários.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum StatusEnum
	{
		Ativo,
		Inativo
	}
}
