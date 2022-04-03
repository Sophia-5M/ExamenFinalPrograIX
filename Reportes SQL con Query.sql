/*                                                  REPORTES                                            */
/*                                   REPORTE PARA OBTENER TOP 10 MARCAS                                 */

SELECT id_marca, COUNT(id_marca) AS Total
FROM tbl_bitacora
GROUP BY id_marca
ORDER BY Total DESC

/*                      EPORTE PARA OBTENER DETALLE DE LOS TIPOS DE VEHÍCULOS Y MODELOS                    */

  SELECT tbl_bitacora.id_tipoV, tbl_tipo_vehiculo.descripcion
  AS Tipo_Vehiculo, tbl_bitacora.id_marca, tbl_marca.descripcion
  FROM tbl_bitacora 
  JOIN tbl_marca
  ON tbl_bitacora.id_marca = tbl_marca.id
  JOIN tbl_tipo_vehiculo 
  ON tbl_bitacora.id_tipoV = tbl_tipo_vehiculo.id_tipo
  ORDER BY id_tipo ASC
