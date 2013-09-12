using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace univer.extractions
{
    public static class QuerysTeachers
    {

        static public string salud()
        {
            return @"
                    SELECT
                      a.claveprofesor, a.nombreprofesor, a.email, b.codigogrupo, b.claveasignatura
                    FROM
                      profesores a, profesores_grupos b
                    WHERE
                      a.claveprofesor = b.claveprofesor AND
                      (b.claveasignatura = 'MPS0101') AND
                      b.id_escuela = 5
                    ";
        }

        static public string rayon() 
        {
            return @"SELECT
                      a.claveprofesor, a.nombreprofesor, a.email, b.codigogrupo, b.claveasignatura
                    FROM
                      profesores a, profesores_grupos b
                    WHERE
                      a.claveprofesor = b.claveprofesor AND
                      (b.claveasignatura = 'MDER0101' OR b.claveasignatura = 'CRIM0103') AND
                      b.id_escuela = 1";
        }

        static public string neza() 
        {
            return @"SELECT
                      a.claveprofesor, a.nombreprofesor, a.email, b.codigogrupo, b.claveasignatura
                    FROM
                      profesores a, profesores_grupos b
                    WHERE
                      a.claveprofesor = b.claveprofesor AND
                      (b.claveasignatura = 'MPS0101' OR b.claveasignatura = 'MPEG0103'  OR b.claveasignatura = 'MPEG0418' OR b.claveasignatura = 'MDER0101' OR b.claveasignatura = 'CRIM0103' ) AND
                      b.id_escuela = 2";
        }

        static public string ixtapaluca() 
        {
            return @"SELECT
                      a.claveprofesor, a.nombreprofesor, a.email, b.codigogrupo, b.claveasignatura
                    FROM
                      profesores a, profesores_grupos b
                    WHERE
                      a.claveprofesor = b.claveprofesor AND
                      (b.claveasignatura = 'MPS0101' OR b.claveasignatura = 'MPEG0103'  OR b.claveasignatura = 'MPEG0418' OR b.claveasignatura = 'MDER0101' OR b.claveasignatura = 'CRIM0103' ) AND
                      b.id_escuela = 3";
        }

        static public string hidalgo() 
        {
            return @"SELECT
                      a.claveprofesor, a.nombreprofesor, a.email, b.codigogrupo, b.claveasignatura
                    FROM
                      profesores a, profesores_grupos b
                    WHERE
                      a.claveprofesor = b.claveprofesor AND
                      (b.claveasignatura = 'MPEG-103' OR b.claveasignatura = 'MPEG-418') AND
                      b.id_escuela = 4";
        }

    }
}
