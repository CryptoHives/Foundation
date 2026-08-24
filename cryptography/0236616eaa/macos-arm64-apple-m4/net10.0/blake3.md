| Description                                  | TestDataSize | Mean             | Error            | StdDev            | Median           | Allocated |
|--------------------------------------------- |------------- |-----------------:|-----------------:|------------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         52.68 ns |         0.032 ns |          0.029 ns |         52.68 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.06 ns |         0.013 ns |          0.011 ns |         54.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         65.04 ns |         1.318 ns |          2.975 ns |         65.75 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         65.24 ns |         0.150 ns |          0.140 ns |         65.24 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         65.80 ns |         0.113 ns |          0.094 ns |         65.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        352.26 ns |         0.094 ns |          0.088 ns |        352.24 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        148.49 ns |         2.969 ns |          2.777 ns |        146.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        150.74 ns |         1.724 ns |          1.613 ns |        150.34 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        471.48 ns |         1.732 ns |          1.535 ns |        472.03 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        511.97 ns |         0.465 ns |          0.412 ns |        511.87 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        544.79 ns |         0.291 ns |          0.272 ns |        544.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |      3,587.03 ns |         2.192 ns |          1.943 ns |      3,586.48 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        472.17 ns |         0.413 ns |          0.386 ns |        472.20 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        512.27 ns |         0.247 ns |          0.206 ns |        512.27 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        547.71 ns |         0.172 ns |          0.144 ns |        547.71 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        590.94 ns |         0.447 ns |          0.396 ns |        590.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        591.09 ns |         0.252 ns |          0.210 ns |        591.04 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |      3,568.62 ns |         1.985 ns |          1.760 ns |      3,568.75 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        199.96 ns |        11.591 ns |         33.626 ns |        178.65 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        693.65 ns |         1.800 ns |          1.596 ns |        693.00 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        778.04 ns |         1.136 ns |          0.887 ns |        777.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        852.35 ns |         0.425 ns |          0.397 ns |        852.45 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        853.53 ns |         1.167 ns |          0.975 ns |        853.65 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      5,342.68 ns |         7.449 ns |          6.603 ns |      5,341.02 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        774.34 ns |         0.166 ns |          0.139 ns |        774.34 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        895.09 ns |         0.321 ns |          0.300 ns |        895.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        895.46 ns |         0.201 ns |          0.188 ns |        895.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        897.12 ns |         0.962 ns |          0.900 ns |        897.32 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        955.29 ns |         1.134 ns |          1.061 ns |        955.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,775.81 ns |        11.824 ns |         11.060 ns |      5,777.25 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        773.77 ns |         0.196 ns |          0.174 ns |        773.75 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        896.04 ns |         0.116 ns |          0.103 ns |        896.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        896.22 ns |         0.112 ns |          0.105 ns |        896.25 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        897.92 ns |         0.405 ns |          0.338 ns |        897.83 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        956.96 ns |         0.095 ns |          0.089 ns |        956.99 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,801.29 ns |         1.161 ns |          0.906 ns |      5,801.59 ns |         - |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        887.05 ns |        10.659 ns |          9.970 ns |        887.45 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,033.46 ns |         0.136 ns |          0.127 ns |      1,033.45 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,034.20 ns |         0.269 ns |          0.252 ns |      1,034.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,096.45 ns |         6.706 ns |          5.945 ns |      1,093.26 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      5,102.85 ns |         2.739 ns |          2.287 ns |      5,102.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      7,208.86 ns |       142.939 ns |        358.607 ns |      7,227.08 ns |      56 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      7,509.02 ns |         2.826 ns |          2.505 ns |      7,508.50 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      8,785.50 ns |         8.774 ns |          8.207 ns |      8,786.41 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      8,806.72 ns |         6.359 ns |          5.310 ns |      8,805.37 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      8,812.12 ns |         3.506 ns |          2.928 ns |      8,812.71 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      9,325.11 ns |         7.635 ns |          6.769 ns |      9,325.08 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     56,384.86 ns |        31.447 ns |         27.877 ns |     56,380.70 ns |      56 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      8,555.59 ns |         2.007 ns |          1.676 ns |      8,555.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      9,693.81 ns |         1.755 ns |          1.466 ns |      9,693.45 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |     10,011.09 ns |         5.492 ns |          4.586 ns |     10,009.46 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |     10,365.28 ns |         6.993 ns |          5.459 ns |     10,363.32 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |     17,876.06 ns |        12.763 ns |         11.939 ns |     17,872.80 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |    114,382.83 ns |       116.555 ns |         97.329 ns |    114,343.70 ns |     168 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |     16,078.21 ns |        12.344 ns |         10.943 ns |     16,076.14 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |     18,657.29 ns |        22.571 ns |         17.622 ns |     18,650.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |     19,377.27 ns |        14.560 ns |         12.907 ns |     19,373.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |     19,399.19 ns |        15.633 ns |         13.054 ns |     19,396.60 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |     26,943.93 ns |        13.600 ns |         12.056 ns |     26,943.15 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |    172,560.77 ns |       119.131 ns |        111.435 ns |    172,530.62 ns |     280 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,353.62 ns |         9.172 ns |          8.579 ns |      3,355.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,909.15 ns |        20.325 ns |         19.012 ns |      3,903.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      4,115.49 ns |        18.071 ns |         16.020 ns |      4,112.37 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,432.60 ns |        84.432 ns |        211.823 ns |      4,374.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,618.88 ns |         1.918 ns |          1.701 ns |      7,619.46 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     48,151.47 ns |       199.484 ns |        186.597 ns |     48,153.50 ns |     392 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,904.63 ns |        22.724 ns |         21.256 ns |      4,893.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,740.72 ns |         2.813 ns |          2.632 ns |      5,740.15 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      6,022.59 ns |        24.082 ns |         22.527 ns |      6,026.98 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,059.50 ns |         1.686 ns |          1.495 ns |      6,059.99 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,386.43 ns |         1.387 ns |          1.297 ns |      9,386.48 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     59,981.19 ns |        11.230 ns |          9.955 ns |     59,980.88 ns |     504 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,794.95 ns |        11.068 ns |          9.243 ns |     27,793.30 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,489.34 ns |         6.157 ns |          5.458 ns |     31,488.97 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     33,974.33 ns |        10.468 ns |          8.741 ns |     33,975.32 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     35,651.00 ns |        47.830 ns |         42.400 ns |     35,662.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,382.16 ns |         7.461 ns |          6.614 ns |     61,380.38 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    390,671.44 ns |        62.841 ns |         58.781 ns |    390,646.44 ns |    3528 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     52,867.61 ns |        12.132 ns |         10.131 ns |     52,868.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     77,453.32 ns |     1,507.331 ns |      2,012.243 ns |     77,816.85 ns |    3357 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |    104,673.12 ns |     2,756.507 ns |      7,261.742 ns |    104,695.61 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |    206,064.06 ns |       143.113 ns |        119.506 ns |    206,024.68 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |    233,051.56 ns |        99.797 ns |         83.335 ns |    233,024.51 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |  2,828,007.82 ns |     2,223.671 ns |      1,971.227 ns |  2,827,752.77 ns |    5432 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     23,757.28 ns |       181.907 ns |        170.156 ns |     23,812.32 ns |    3568 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     54,896.34 ns |       453.368 ns |        424.081 ns |     54,696.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     59,858.16 ns |       652.952 ns |        509.782 ns |     59,632.88 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |    329,629.04 ns |       175.410 ns |        146.476 ns |    329,662.11 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    580,578.11 ns |       377.649 ns |        353.253 ns |    580,469.12 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |  3,694,045.90 ns |     2,316.497 ns |      1,934.380 ns |  3,693,574.06 ns |    7112 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |     37,242.15 ns |       315.493 ns |        295.112 ns |     37,121.01 ns |    4089 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    110,387.67 ns |       289.572 ns |        270.866 ns |    110,357.00 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    125,889.57 ns |       119.438 ns |        111.722 ns |    125,874.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    133,908.95 ns |       668.909 ns |        625.698 ns |    133,994.80 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    246,941.91 ns |        72.940 ns |         60.909 ns |    246,936.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,565,662.37 ns |       317.542 ns |        297.029 ns |  1,565,615.97 ns |   14280 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |     71,669.02 ns |     1,428.477 ns |      1,336.199 ns |     71,225.58 ns |    3823 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    222,816.19 ns |        73.859 ns |         65.474 ns |    222,797.74 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    251,874.98 ns |        41.775 ns |         39.077 ns |    251,877.83 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    269,846.03 ns |        88.792 ns |         83.056 ns |    269,849.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    494,166.26 ns |        89.983 ns |         84.170 ns |    494,157.55 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  3,133,205.77 ns |       901.345 ns |        752.663 ns |  3,133,215.90 ns |   28616 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    108,603.58 ns |     1,397.245 ns |      1,306.984 ns |    108,177.83 ns |    3838 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    404,601.35 ns |     1,669.199 ns |      1,561.370 ns |    404,110.92 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    472,650.10 ns |     1,268.792 ns |      1,186.829 ns |    472,564.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    511,134.07 ns |        84.716 ns |         75.099 ns |    511,139.85 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    942,739.50 ns |       113.548 ns |        100.657 ns |    942,724.20 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          | 14,048,821.76 ns | 3,592,095.926 ns | 10,591,376.652 ns |  6,663,121.10 ns |   54656 B |
|                                              |              |                  |                  |                   |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  1,592,730.71 ns |    90,128.412 ns |    235,850.364 ns |  1,622,449.73 ns |    3775 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,253,428.33 ns |     1,898.756 ns |      1,482.424 ns |  4,253,223.64 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,807,828.62 ns |     1,349.154 ns |      1,261.999 ns |  4,808,078.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  5,104,898.95 ns |     1,691.867 ns |      1,499.796 ns |  5,104,816.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,421,695.74 ns |     1,258.190 ns |      1,176.911 ns |  9,421,693.36 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 59,791,436.25 ns |    11,963.250 ns |      9,989.855 ns | 59,789,143.44 ns |  546840 B |