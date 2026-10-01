| Description                                         | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|---------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |         46.40 ns |      0.050 ns |      0.047 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |         46.83 ns |      0.157 ns |      0.139 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |         53.79 ns |      0.123 ns |      0.115 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |         54.74 ns |      0.170 ns |      0.159 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |         61.50 ns |      0.213 ns |      0.199 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 4B           |         61.51 ns |      0.191 ns |      0.169 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |        394.20 ns |      0.986 ns |      0.922 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64B          |         43.95 ns |      0.022 ns |      0.020 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64B          |         44.40 ns |      0.113 ns |      0.100 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64B          |         50.91 ns |      0.035 ns |      0.031 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 64B          |         51.19 ns |      0.034 ns |      0.032 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64B          |         53.20 ns |      0.016 ns |      0.015 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64B          |         54.50 ns |      0.032 ns |      0.027 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64B          |        386.05 ns |      0.433 ns |      0.384 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 65B          |         94.75 ns |      0.231 ns |      0.216 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 65B          |         94.83 ns |      0.132 ns |      0.117 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 65B          |         99.40 ns |      0.065 ns |      0.061 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 65B          |        108.85 ns |      0.041 ns |      0.037 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 65B          |        110.00 ns |      0.034 ns |      0.030 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 65B          |        110.04 ns |      0.016 ns |      0.013 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 65B          |        759.59 ns |      2.249 ns |      2.104 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |         94.61 ns |      0.150 ns |      0.133 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |         94.70 ns |      0.178 ns |      0.167 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |         99.31 ns |      0.101 ns |      0.090 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |        106.82 ns |      0.021 ns |      0.019 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 100B         |        106.84 ns |      0.019 ns |      0.015 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |        108.51 ns |      0.110 ns |      0.098 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |        755.10 ns |      2.677 ns |      2.504 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |         93.65 ns |      0.245 ns |      0.229 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |         93.81 ns |      0.183 ns |      0.162 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |         99.17 ns |      0.157 ns |      0.147 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |        101.96 ns |      0.027 ns |      0.022 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 128B         |        101.97 ns |      0.033 ns |      0.029 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |        108.59 ns |      0.028 ns |      0.024 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |        750.24 ns |      2.628 ns |      2.458 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |        142.28 ns |      0.562 ns |      0.526 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |        142.42 ns |      0.416 ns |      0.389 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |        145.77 ns |      0.431 ns |      0.403 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 137B         |        159.30 ns |      0.041 ns |      0.036 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |        159.34 ns |      0.053 ns |      0.049 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |        164.37 ns |      0.210 ns |      0.186 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |      1,117.76 ns |      5.987 ns |      5.600 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |        763.38 ns |      2.735 ns |      2.425 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |        768.43 ns |      3.139 ns |      2.936 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |        768.72 ns |      1.895 ns |      1.773 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |        801.31 ns |      0.223 ns |      0.209 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1000B        |        801.33 ns |      0.473 ns |      0.395 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |        894.14 ns |      0.780 ns |      0.651 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |      5,656.84 ns |     14.408 ns |     13.477 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |        762.51 ns |      2.325 ns |      2.175 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |        767.07 ns |      2.490 ns |      2.329 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |        767.16 ns |      2.034 ns |      1.903 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1KB          |        797.73 ns |      0.307 ns |      0.272 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |        797.73 ns |      0.154 ns |      0.136 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |        895.16 ns |      0.701 ns |      0.621 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |      5,667.18 ns |     16.968 ns |     15.872 ns |         - |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |        862.75 ns |      1.912 ns |      1.788 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |        866.00 ns |      3.280 ns |      2.908 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |        866.13 ns |      2.316 ns |      2.167 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1025B        |        902.51 ns |      0.552 ns |      0.516 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |        902.85 ns |      0.260 ns |      0.230 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |      1,011.41 ns |      1.074 ns |      1.004 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |      6,441.25 ns |     16.639 ns |     14.750 ns |      56 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |      1,565.58 ns |      4.868 ns |      4.315 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |      1,586.30 ns |      4.391 ns |      4.107 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |      1,587.25 ns |      5.227 ns |      4.890 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 2KB          |      1,624.68 ns |      0.588 ns |      0.491 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |      1,626.00 ns |      0.320 ns |      0.299 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |      1,857.30 ns |      1.573 ns |      1.394 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |     11,671.79 ns |     24.078 ns |     21.345 ns |      56 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 3KB          |      1,707.50 ns |      7.166 ns |      6.353 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 3KB          |      1,896.52 ns |      7.351 ns |      6.876 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 3KB          |      1,907.29 ns |      6.933 ns |      6.485 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 3KB          |      2,371.26 ns |     10.330 ns |      9.157 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 3KB          |      2,461.15 ns |      1.043 ns |      0.976 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 3KB          |      2,879.61 ns |      2.383 ns |      1.990 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 3KB          |     17,637.64 ns |     77.956 ns |     72.920 ns |     112 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |      1,645.32 ns |      6.440 ns |      6.024 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 4KB          |      1,779.34 ns |      4.753 ns |      4.446 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |      1,921.64 ns |     10.036 ns |      8.897 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |      1,937.49 ns |      5.760 ns |      4.497 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |      1,942.73 ns |      8.289 ns |      7.753 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |      3,294.32 ns |      1.075 ns |      0.953 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |     23,687.26 ns |     74.445 ns |     69.636 ns |     168 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 5KB          |      2,375.72 ns |     15.942 ns |     14.912 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 5KB          |      2,571.13 ns |     10.930 ns |     10.224 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 5KB          |      2,700.21 ns |     11.616 ns |     10.866 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 5KB          |      2,702.35 ns |     13.705 ns |     12.149 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 5KB          |      2,888.47 ns |      9.312 ns |      8.710 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 5KB          |      4,128.63 ns |      1.286 ns |      1.202 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 5KB          |     29,702.76 ns |     79.918 ns |     70.845 ns |     224 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |      3,162.14 ns |     13.269 ns |     12.412 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 6KB          |      3,426.10 ns |     12.227 ns |     11.437 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |      3,502.39 ns |     13.632 ns |     12.085 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |      3,508.10 ns |      9.786 ns |      9.154 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |      3,766.25 ns |     18.665 ns |     17.459 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |      4,960.44 ns |      4.031 ns |      3.147 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |     35,773.11 ns |    140.481 ns |    124.533 ns |     280 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |      3,252.26 ns |     16.488 ns |     14.616 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 8KB          |      3,604.79 ns |      9.748 ns |      9.118 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |      3,802.95 ns |     21.244 ns |     19.872 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |      3,881.55 ns |     12.149 ns |     10.770 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |      3,882.77 ns |     13.652 ns |     12.102 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |      6,626.53 ns |      1.400 ns |      1.169 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |     47,766.98 ns |    130.797 ns |    122.348 ns |     392 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 9216B        |      3,983.31 ns |     15.203 ns |     14.221 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 9216B        |      4,374.72 ns |     25.305 ns |     23.670 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 9216B        |      4,610.90 ns |     27.026 ns |     25.280 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 9216B        |      4,617.42 ns |     33.215 ns |     29.444 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 9216B        |      4,717.13 ns |     28.195 ns |     26.374 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 9216B        |      7,460.77 ns |      1.024 ns |      0.958 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 9216B        |     53,592.18 ns |    184.529 ns |    163.580 ns |     448 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |      4,563.61 ns |     28.971 ns |     25.682 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10000B       |      5,066.00 ns |     47.611 ns |     44.535 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |      5,253.92 ns |     24.836 ns |     23.232 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |      5,254.84 ns |     24.006 ns |     21.281 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |      5,443.66 ns |     22.710 ns |     21.243 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |      8,150.57 ns |      2.386 ns |      2.232 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |     58,542.34 ns |    146.296 ns |    136.845 ns |     504 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10240B       |      4,700.55 ns |     37.873 ns |     35.426 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10240B       |      5,206.98 ns |     26.181 ns |     24.490 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10240B       |      5,393.02 ns |     30.097 ns |     28.153 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10240B       |      5,408.95 ns |     51.462 ns |     45.620 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10240B       |      5,610.38 ns |     21.362 ns |     19.982 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10240B       |      8,295.87 ns |      3.218 ns |      3.010 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10240B       |     59,579.44 ns |    202.534 ns |    179.541 ns |     504 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 11264B       |      5,369.06 ns |     17.564 ns |     16.429 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 11264B       |      5,479.18 ns |     30.226 ns |     26.795 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 11264B       |      5,773.88 ns |     17.225 ns |     16.112 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 11264B       |      5,784.54 ns |     25.695 ns |     24.035 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 11264B       |      6,490.17 ns |     27.459 ns |     25.685 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 11264B       |      9,126.36 ns |      3.328 ns |      3.113 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 11264B       |     65,521.02 ns |    280.027 ns |    261.938 ns |     560 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 12288B       |      4,850.63 ns |     31.828 ns |     29.772 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 12288B       |      5,429.37 ns |     27.126 ns |     25.374 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 12288B       |      5,652.63 ns |     30.932 ns |     28.934 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 12288B       |      5,824.59 ns |     17.850 ns |     16.697 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 12288B       |      5,825.22 ns |     15.846 ns |     14.047 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 12288B       |      9,958.24 ns |      2.779 ns |      2.600 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 12288B       |     71,826.11 ns |    455.871 ns |    404.117 ns |     616 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 15360B       |      7,026.44 ns |     33.526 ns |     31.360 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 15360B       |      7,202.73 ns |     18.236 ns |     17.058 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 15360B       |      7,702.21 ns |     33.240 ns |     29.466 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 15360B       |      7,723.39 ns |     26.714 ns |     24.989 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 15360B       |      8,328.31 ns |     48.430 ns |     45.302 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 15360B       |     12,465.57 ns |      2.351 ns |      2.199 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 15360B       |     89,561.19 ns |    409.784 ns |    363.263 ns |     784 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 16KB         |      6,479.43 ns |     36.825 ns |     34.446 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 16KB         |      7,254.74 ns |     14.899 ns |     13.208 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 16KB         |      7,551.85 ns |     28.308 ns |     26.479 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 16KB         |      7,760.90 ns |     20.080 ns |     16.767 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 16KB         |      7,773.41 ns |     46.161 ns |     43.179 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 16KB         |     13,294.26 ns |      3.194 ns |      2.832 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 16KB         |     95,657.48 ns |    318.915 ns |    282.710 ns |     840 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |     16,135.34 ns |    179.622 ns |    168.018 ns |     128 B |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 64KB         |     27,132.19 ns |     77.390 ns |     72.391 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |     27,760.43 ns |    168.265 ns |    157.395 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |     31,777.30 ns |    123.342 ns |    115.374 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |     33,241.00 ns |     38.968 ns |     36.450 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |     53,293.62 ns |     15.058 ns |     13.348 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |    391,818.10 ns |  3,975.877 ns |  3,524.511 ns |    3528 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |     17,643.35 ns |     93.425 ns |     78.014 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |     43,645.61 ns |    121.334 ns |    113.496 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 100000B      |     46,408.61 ns |     62.284 ns |     58.260 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |     49,582.68 ns |     64.363 ns |     53.746 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |     51,434.60 ns |     14.323 ns |     12.697 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |     82,811.26 ns |     21.470 ns |     19.033 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |    608,663.30 ns |    217.981 ns |    203.900 ns |    5432 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |     19,705.82 ns |    106.320 ns |     99.452 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |     56,511.32 ns |     39.239 ns |     36.704 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 128KB        |     58,684.83 ns |     14.220 ns |     13.301 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |     64,028.87 ns |     27.026 ns |     25.280 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |     66,571.55 ns |      9.973 ns |      8.328 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |    108,733.68 ns |     54.597 ns |     48.399 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |    798,421.78 ns |    247.199 ns |    219.136 ns |    7112 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |     91,338.63 ns |    518.270 ns |    459.432 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |    432,245.69 ns |    272.495 ns |    254.892 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1MB          |    449,314.56 ns |     41.277 ns |     34.468 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |    488,505.84 ns |    127.127 ns |    118.915 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |    507,978.73 ns |     82.396 ns |     68.804 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |    827,972.99 ns |    180.603 ns |    160.100 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |  6,083,340.15 ns |  1,891.590 ns |  1,676.845 ns |   54656 B |
|                                                     |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |    835,245.38 ns |  3,222.491 ns |  2,856.654 ns |     136 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |  4,323,230.25 ns |  3,335.022 ns |  3,119.582 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10MB         |  4,489,186.36 ns |  1,075.277 ns |    953.205 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |  4,885,368.39 ns |  1,425.141 ns |  1,263.350 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |  5,078,721.74 ns |  1,069.566 ns |    948.143 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         |  8,287,700.01 ns |  3,387.215 ns |  3,002.678 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 60,717,026.21 ns | 18,590.644 ns | 17,389.700 ns |  546840 B |