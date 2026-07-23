| Description                                   | TestDataSize | Mean             | Error            | StdDev           | Median           | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|-----------------:|-----------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.61 ns |         1.016 ns |         0.951 ns |         56.06 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         61.83 ns |         0.663 ns |         0.517 ns |         61.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         62.12 ns |         1.252 ns |         1.286 ns |         61.47 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         62.63 ns |         1.265 ns |         1.184 ns |         61.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         63.13 ns |         1.285 ns |         1.578 ns |         62.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         75.61 ns |         1.226 ns |         1.146 ns |         75.05 ns |   5,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |        301.41 ns |         5.537 ns |         5.180 ns |        300.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        606.89 ns |         9.756 ns |         9.126 ns |        604.97 ns |  21,324 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         98.42 ns |         1.546 ns |         1.371 ns |         97.94 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        105.92 ns |         1.160 ns |         1.085 ns |        105.56 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        108.61 ns |         1.799 ns |         1.682 ns |        107.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        109.19 ns |         2.081 ns |         1.947 ns |        108.30 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        109.59 ns |         2.160 ns |         2.020 ns |        109.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.72 ns |         2.138 ns |         1.895 ns |        120.79 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        597.89 ns |        11.352 ns |        11.150 ns |        594.83 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,294.48 ns |        25.029 ns |        24.581 ns |      1,285.77 ns |  21,991 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         95.23 ns |         1.869 ns |         1.920 ns |         94.28 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        108.08 ns |         1.099 ns |         0.917 ns |        108.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        108.11 ns |         2.186 ns |         2.430 ns |        107.77 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        108.50 ns |         2.050 ns |         1.917 ns |        107.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        109.13 ns |         2.166 ns |         2.740 ns |        108.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        118.69 ns |         2.304 ns |         2.366 ns |        117.72 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        594.36 ns |        10.250 ns |         9.588 ns |        592.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,334.29 ns |        25.086 ns |        26.842 ns |      1,324.96 ns |  21,985 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        150.70 ns |         2.642 ns |         2.471 ns |        149.66 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        161.88 ns |         2.695 ns |         2.521 ns |        160.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        162.88 ns |         3.129 ns |         3.073 ns |        161.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        163.33 ns |         3.244 ns |         3.861 ns |        161.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        165.45 ns |         3.192 ns |         3.548 ns |        164.73 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        169.50 ns |         3.336 ns |         3.426 ns |        167.48 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        874.05 ns |        10.333 ns |         9.160 ns |        873.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,956.52 ns |        32.209 ns |        30.128 ns |      1,944.84 ns |  21,985 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        763.26 ns |        14.379 ns |        14.122 ns |        758.29 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        800.89 ns |        16.001 ns |        28.025 ns |        788.20 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        821.35 ns |         5.460 ns |         4.263 ns |        821.91 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        849.75 ns |        13.529 ns |        11.993 ns |        845.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        853.91 ns |        16.536 ns |        17.694 ns |        845.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        856.10 ns |        16.472 ns |        20.832 ns |        842.47 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      4,619.94 ns |        91.481 ns |        85.572 ns |      4,612.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,311.99 ns |       196.490 ns |       201.781 ns |     10,279.41 ns |  22,003 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        784.59 ns |         6.180 ns |         5.478 ns |        782.54 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        847.68 ns |        16.544 ns |        23.193 ns |        848.12 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        847.77 ns |         9.296 ns |         8.241 ns |        844.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        850.94 ns |        16.933 ns |        15.839 ns |        843.51 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        853.35 ns |        16.509 ns |        16.954 ns |        845.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        949.87 ns |         6.502 ns |         5.076 ns |        948.22 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      4,610.87 ns |        81.096 ns |        75.857 ns |      4,597.43 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |     10,013.66 ns |       169.514 ns |       150.269 ns |     10,018.04 ns |  22,012 B |         - |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        843.67 ns |        16.213 ns |        14.372 ns |        838.57 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        952.78 ns |         5.396 ns |         4.506 ns |        951.33 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        955.87 ns |         6.890 ns |         6.108 ns |        953.57 ns |   4,875 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        991.26 ns |        16.950 ns |        15.026 ns |        985.93 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        994.77 ns |        18.960 ns |        20.287 ns |        982.30 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        998.86 ns |        19.406 ns |        19.060 ns |        986.61 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      5,399.84 ns |       107.915 ns |       119.947 ns |      5,365.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     11,217.92 ns |       195.450 ns |       304.293 ns |     11,143.49 ns |  22,323 B |      56 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        794.11 ns |        11.002 ns |        10.291 ns |        790.99 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,245.73 ns |        15.771 ns |        14.752 ns |      1,242.58 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,255.58 ns |        24.063 ns |        26.746 ns |      1,242.84 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,678.86 ns |        11.329 ns |        10.043 ns |      1,678.39 ns |  11,378 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,762.28 ns |        31.243 ns |        29.225 ns |      1,757.43 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,792.73 ns |        26.953 ns |        25.212 ns |      1,781.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      9,803.66 ns |       186.828 ns |       183.490 ns |      9,760.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     20,676.43 ns |       355.921 ns |       332.929 ns |     20,686.11 ns |  22,238 B |      56 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,022.24 ns |        12.187 ns |        10.177 ns |      1,018.47 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,357.83 ns |        23.852 ns |        22.312 ns |      1,347.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,373.08 ns |        20.543 ns |        19.216 ns |      1,374.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,138.14 ns |        30.823 ns |        25.739 ns |      2,127.56 ns |  18,024 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,503.85 ns |        20.016 ns |        16.714 ns |      3,503.60 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,646.40 ns |        70.972 ns |        66.387 ns |      3,618.38 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |     19,946.05 ns |       246.982 ns |       231.028 ns |     19,904.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     40,027.69 ns |       675.409 ns |       598.733 ns |     39,857.28 ns |  22,230 B |     168 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,500.20 ns |        22.157 ns |        19.642 ns |      1,497.93 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,509.55 ns |        23.351 ns |        21.843 ns |      1,501.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,835.59 ns |        28.547 ns |        23.838 ns |      1,831.45 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      3,077.38 ns |        59.675 ns |        71.039 ns |      3,053.43 ns |  18,144 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,299.85 ns |        64.728 ns |        54.051 ns |      5,271.34 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,476.13 ns |       108.324 ns |       111.241 ns |      5,429.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |     30,008.15 ns |       284.640 ns |       252.326 ns |     30,062.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     63,834.05 ns |       881.406 ns |       781.343 ns |     63,925.73 ns |  22,235 B |     280 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,180.93 ns |        21.606 ns |        21.220 ns |      1,171.43 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,481.48 ns |        22.529 ns |        21.074 ns |      1,472.83 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,596.64 ns |        31.288 ns |        30.729 ns |      1,583.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,603.17 ns |        19.348 ns |        18.098 ns |      1,607.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,469.36 ns |        48.447 ns |        55.792 ns |      2,469.80 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,320.63 ns |       106.736 ns |        94.618 ns |      7,297.89 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     40,408.04 ns |       785.166 ns |       964.254 ns |     40,398.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     83,866.25 ns |     1,279.284 ns |     1,196.643 ns |     83,938.38 ns |  22,272 B |     392 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,630.44 ns |        52.372 ns |        56.037 ns |      2,600.39 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,088.34 ns |        61.626 ns |        57.645 ns |      3,054.51 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,133.73 ns |        47.218 ns |        44.168 ns |      3,128.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,221.30 ns |        63.076 ns |        64.775 ns |      3,214.92 ns |  18,537 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,481.70 ns |        58.514 ns |        54.734 ns |      3,475.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      9,024.67 ns |       158.431 ns |       148.197 ns |      9,034.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     49,565.12 ns |       853.553 ns |       798.414 ns |     49,510.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    102,605.21 ns |     1,654.927 ns |     1,548.020 ns |    102,275.77 ns |  22,259 B |     504 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,412.04 ns |       120.331 ns |       106.670 ns |      7,438.55 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      8,974.71 ns |       178.187 ns |       166.676 ns |      8,929.58 ns |   8,626 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |     10,847.10 ns |       147.818 ns |       138.269 ns |     10,853.89 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,986.04 ns |        81.376 ns |        76.119 ns |     11,969.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     14,153.15 ns |       106.925 ns |        83.480 ns |     14,162.05 ns |  18,195 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     58,571.76 ns |       610.086 ns |       509.450 ns |     58,318.88 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |    321,568.32 ns |     5,772.244 ns |     5,399.360 ns |    320,552.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    672,632.64 ns |    12,521.608 ns |    12,858.769 ns |    668,690.09 ns |  22,258 B |    3528 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,413.34 ns |       133.494 ns |       111.473 ns |     12,388.33 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     15,029.92 ns |       208.520 ns |       195.050 ns |     14,947.67 ns |   8,950 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     15,691.02 ns |       227.239 ns |       212.560 ns |     15,617.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,892.47 ns |       310.649 ns |       290.581 ns |     17,751.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     18,102.06 ns |       277.933 ns |       259.979 ns |     18,040.86 ns |  30,586 B |    2329 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     90,174.86 ns |     1,513.421 ns |     1,341.608 ns |     90,057.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    491,266.55 ns |     6,948.138 ns |     6,499.293 ns |    491,772.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,019,336.83 ns |    12,022.445 ns |    10,657.584 ns |  1,018,140.82 ns |  22,247 B |    5432 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,531.87 ns |       130.905 ns |       116.044 ns |     14,490.52 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     19,758.85 ns |       380.565 ns |       494.843 ns |     19,566.21 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,978.19 ns |       243.345 ns |       215.719 ns |     19,928.80 ns |  30,259 B |    2546 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     20,871.64 ns |       416.652 ns |       479.817 ns |     20,738.87 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,627.05 ns |       312.525 ns |       292.336 ns |     22,495.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    117,852.51 ns |     2,113.736 ns |     1,977.190 ns |    116,621.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    646,657.83 ns |    10,474.997 ns |     9,285.812 ns |    647,736.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,361,404.40 ns |    24,467.225 ns |    22,886.657 ns |  1,350,387.11 ns |  22,258 B |    7112 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     25,840.00 ns |       366.029 ns |       342.384 ns |     25,711.07 ns |  30,729 B |    2901 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     29,181.94 ns |       336.440 ns |       314.706 ns |     29,182.93 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     35,417.37 ns |       332.360 ns |       310.890 ns |     35,409.27 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     36,964.29 ns |       334.402 ns |       296.439 ns |     36,883.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     43,181.56 ns |       815.159 ns |       762.501 ns |     42,789.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    233,533.73 ns |     2,377.453 ns |     1,985.281 ns |    232,873.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |  1,300,252.68 ns |    25,628.309 ns |    27,422.004 ns |  1,291,167.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,778,564.10 ns |    54,697.530 ns |    60,796.160 ns |  2,757,116.41 ns |  22,258 B |   14280 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     30,258.23 ns |       592.755 ns |       554.463 ns |     30,266.95 ns |  30,315 B |    3694 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     58,183.52 ns |       867.174 ns |       811.156 ns |     57,856.42 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     70,455.13 ns |     1,317.015 ns |     1,167.500 ns |     70,007.66 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     74,027.13 ns |     1,407.924 ns |     1,316.973 ns |     73,564.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     86,117.86 ns |     1,709.817 ns |     1,755.856 ns |     85,820.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    475,016.49 ns |     7,411.765 ns |     6,570.336 ns |    475,110.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |  2,601,168.53 ns |    48,985.878 ns |    48,110.682 ns |  2,614,635.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,414,916.96 ns |    68,358.121 ns |    60,597.694 ns |  5,403,137.89 ns |  22,257 B |   28616 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     37,118.79 ns |       216.117 ns |       202.156 ns |     37,073.81 ns |  29,896 B |    4115 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    113,057.25 ns |     2,020.287 ns |     1,889.777 ns |    112,900.24 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    137,318.96 ns |     2,674.555 ns |     2,746.571 ns |    136,933.40 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    153,871.31 ns |     2,959.547 ns |     2,768.362 ns |    152,674.32 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    161,132.02 ns |     2,078.369 ns |     1,735.532 ns |    160,838.55 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    899,707.67 ns |    14,420.270 ns |    12,783.194 ns |    894,165.04 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  4,842,304.79 ns |    64,324.391 ns |    60,169.075 ns |  4,847,657.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,743,076.25 ns |   150,224.834 ns |   140,520.403 ns |  9,705,853.12 ns |  22,258 B |   54656 B |
|                                               |              |                  |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    379,984.88 ns |     5,655.288 ns |     5,013.265 ns |    379,161.69 ns |  37,367 B |    4112 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,248,375.91 ns |    23,390.250 ns |    25,027.306 ns |  1,242,967.29 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,628,068.82 ns |    31,349.267 ns |    30,789.172 ns |  1,618,966.11 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,786,180.70 ns |    33,792.241 ns |    36,157.319 ns |  1,774,964.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,951,733.30 ns |    38,626.523 ns |    45,982.132 ns |  1,931,132.23 ns |   8,899 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  8,936,426.92 ns |   124,905.924 ns |   104,302.104 ns |  8,911,129.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 48,499,916.88 ns |   486,026.373 ns |   430,849.720 ns | 48,402,745.45 ns |        NA |    1121 B |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 97,118,981.43 ns | 1,665,272.881 ns | 1,476,221.034 ns | 96,518,070.00 ns |  22,370 B |  546840 B |