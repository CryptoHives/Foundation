| Description                                     | TestDataSize | Mean             | Error          | StdDev         | Allocated |
|------------------------------------------------ |------------- |-----------------:|---------------:|---------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |         45.93 ns |       0.286 ns |       0.254 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |         46.06 ns |       0.139 ns |       0.123 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |         52.49 ns |       0.155 ns |       0.121 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |         53.74 ns |       0.183 ns |       0.171 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4B           |         60.54 ns |       0.145 ns |       0.135 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         60.74 ns |       0.221 ns |       0.206 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |        376.74 ns |       1.498 ns |       1.401 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |         43.16 ns |       0.183 ns |       0.171 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |         43.38 ns |       0.205 ns |       0.192 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64B          |         51.44 ns |       0.125 ns |       0.117 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         51.62 ns |       0.238 ns |       0.222 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |         53.42 ns |       0.148 ns |       0.138 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |         53.70 ns |       0.192 ns |       0.180 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |        378.68 ns |       1.532 ns |       1.433 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         91.61 ns |       0.313 ns |       0.293 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         91.63 ns |       0.411 ns |       0.384 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         97.98 ns |       0.342 ns |       0.320 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |        108.93 ns |       0.265 ns |       0.247 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 65B          |        110.39 ns |       0.359 ns |       0.336 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |        110.43 ns |       0.319 ns |       0.299 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |        744.92 ns |       2.247 ns |       1.992 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         91.67 ns |       0.423 ns |       0.396 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         91.78 ns |       0.365 ns |       0.341 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         98.35 ns |       0.358 ns |       0.335 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |        107.25 ns |       0.301 ns |       0.281 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100B         |        107.28 ns |       0.420 ns |       0.393 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |        108.47 ns |       0.393 ns |       0.367 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |        746.41 ns |       2.593 ns |       2.299 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         90.84 ns |       0.405 ns |       0.338 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         90.99 ns |       0.338 ns |       0.300 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         98.19 ns |       0.303 ns |       0.283 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128B         |        102.35 ns |       0.279 ns |       0.247 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |        102.47 ns |       0.339 ns |       0.317 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |        108.68 ns |       0.207 ns |       0.183 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |        748.41 ns |       3.182 ns |       2.976 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |        136.74 ns |       0.560 ns |       0.496 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |        136.99 ns |       0.661 ns |       0.618 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |        144.66 ns |       0.673 ns |       0.629 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 137B         |        159.89 ns |       0.586 ns |       0.548 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |        160.03 ns |       0.503 ns |       0.471 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |        163.45 ns |       0.558 ns |       0.522 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |      1,107.01 ns |       4.405 ns |       4.121 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |        736.51 ns |       3.143 ns |       2.940 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |        736.68 ns |       3.136 ns |       2.780 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |        757.83 ns |       3.449 ns |       3.226 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |        803.94 ns |       3.040 ns |       2.844 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1000B        |        804.47 ns |       3.224 ns |       3.016 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |        889.38 ns |       3.073 ns |       2.875 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      5,608.10 ns |      20.237 ns |      17.939 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |        736.74 ns |       2.944 ns |       2.753 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |        737.78 ns |       2.723 ns |       2.547 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |        756.50 ns |       2.513 ns |       2.350 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |        799.39 ns |       2.576 ns |       2.409 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1KB          |        800.94 ns |       2.641 ns |       2.471 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |        898.55 ns |      13.652 ns |      14.020 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      5,640.04 ns |      22.291 ns |      20.851 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |        832.01 ns |       3.718 ns |       3.478 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |        832.19 ns |       3.755 ns |       3.512 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |        857.58 ns |       2.866 ns |       2.681 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1025B        |        902.75 ns |       3.251 ns |       3.041 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |        905.57 ns |       3.018 ns |       2.823 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |      1,007.34 ns |       4.009 ns |       3.750 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      6,399.26 ns |      22.992 ns |      21.506 ns |      56 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |      1,521.75 ns |       6.356 ns |       5.946 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |      1,523.36 ns |       6.676 ns |       6.245 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |      1,554.47 ns |       4.523 ns |       4.010 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 2KB          |      1,629.44 ns |       6.059 ns |       5.667 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |      1,632.84 ns |       4.426 ns |       4.140 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |      1,850.39 ns |       7.876 ns |       7.367 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |     11,621.30 ns |      53.153 ns |      49.720 ns |      56 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |      1,648.56 ns |       3.358 ns |       3.141 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |      1,651.43 ns |       6.060 ns |       5.669 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 3KB          |      1,696.51 ns |       8.487 ns |       7.938 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |      2,350.20 ns |       9.843 ns |       8.725 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |      2,457.86 ns |       0.995 ns |       0.930 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |      2,856.14 ns |       9.969 ns |       9.325 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |     17,824.00 ns |     353.540 ns |     378.284 ns |     112 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |      1,638.58 ns |       3.660 ns |       3.424 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |      1,690.73 ns |       7.335 ns |       6.861 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |      1,691.66 ns |       5.024 ns |       4.700 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4KB          |      1,755.54 ns |       5.281 ns |       4.940 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |      1,906.10 ns |       7.672 ns |       7.176 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |      3,292.26 ns |       0.792 ns |       0.741 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |     23,451.70 ns |      76.787 ns |      71.826 ns |     168 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |      2,369.41 ns |      11.253 ns |      10.526 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |      2,396.95 ns |      15.098 ns |      14.122 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |      2,400.11 ns |      14.665 ns |      13.717 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 5KB          |      2,552.26 ns |      12.528 ns |      11.719 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |      2,858.70 ns |      12.865 ns |      12.034 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      4,124.91 ns |       1.995 ns |       1.866 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |     29,454.01 ns |      56.597 ns |      50.172 ns |     224 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |      3,131.58 ns |      16.527 ns |      15.460 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |      3,163.07 ns |      19.693 ns |      18.421 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |      3,163.51 ns |      17.091 ns |      15.987 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 6KB          |      3,387.21 ns |      14.839 ns |      13.881 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |      3,740.59 ns |      13.328 ns |      12.467 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      4,956.64 ns |       1.692 ns |       1.500 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |     35,390.71 ns |     126.757 ns |     118.568 ns |     280 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |      3,258.61 ns |      12.862 ns |      12.031 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |      3,377.04 ns |      18.337 ns |      17.152 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |      3,379.67 ns |      16.053 ns |      13.405 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 8KB          |      3,558.62 ns |       7.995 ns |       7.087 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |      3,778.09 ns |      19.290 ns |      18.044 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      6,632.05 ns |      15.528 ns |      13.765 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |     47,554.59 ns |     265.097 ns |     247.972 ns |     392 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |      3,977.95 ns |       4.377 ns |       3.655 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |      4,060.94 ns |      11.942 ns |      11.171 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |      4,064.73 ns |      14.044 ns |      13.136 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 9216B        |      4,356.14 ns |      27.873 ns |      26.073 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |      4,677.75 ns |      20.631 ns |      19.299 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      7,492.90 ns |      27.245 ns |      25.485 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     53,200.70 ns |     145.529 ns |     136.128 ns |     448 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |      4,549.94 ns |      19.334 ns |      18.085 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |      4,636.18 ns |      29.370 ns |      27.473 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |      4,662.52 ns |      35.705 ns |      33.398 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10000B       |      5,008.73 ns |      28.199 ns |      26.377 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |      5,389.52 ns |      21.665 ns |      16.915 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      8,144.34 ns |       2.914 ns |       2.726 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     58,316.86 ns |     166.187 ns |     138.774 ns |     504 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |      4,707.11 ns |      23.689 ns |      22.159 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |      4,789.27 ns |      27.470 ns |      24.351 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |      4,795.97 ns |      34.574 ns |      32.341 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10240B       |      5,184.80 ns |      26.840 ns |      25.106 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |      5,591.90 ns |      26.445 ns |      24.737 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      8,326.31 ns |      30.925 ns |      28.927 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     59,558.96 ns |     245.867 ns |     229.984 ns |     504 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |      5,063.63 ns |      39.452 ns |      36.903 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |      5,070.79 ns |      34.277 ns |      32.063 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 11264B       |      5,342.83 ns |      22.089 ns |      20.662 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |      5,476.41 ns |      25.376 ns |      23.736 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      6,488.92 ns |      27.889 ns |      26.088 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      9,170.09 ns |      26.466 ns |      24.757 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     65,659.82 ns |     353.663 ns |     330.816 ns |     560 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |      4,876.09 ns |      28.384 ns |      26.551 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |      5,061.27 ns |      27.057 ns |      25.309 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |      5,074.13 ns |      31.554 ns |      29.515 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 12288B       |      5,408.30 ns |      22.033 ns |      19.532 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      5,654.30 ns |      24.824 ns |      23.221 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      9,999.96 ns |      25.752 ns |      24.089 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     71,929.55 ns |     344.519 ns |     322.263 ns |     616 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |      6,769.83 ns |      30.778 ns |      28.790 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |      6,777.24 ns |      44.088 ns |      41.240 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |      7,053.21 ns |      29.073 ns |      25.772 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 15360B       |      7,185.13 ns |      28.504 ns |      26.662 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      8,341.45 ns |      45.007 ns |      42.100 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |     12,515.96 ns |      30.704 ns |      28.720 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     89,728.13 ns |     318.454 ns |     297.882 ns |     784 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |      6,447.33 ns |      26.603 ns |      24.884 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |      6,742.34 ns |      20.418 ns |      18.100 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |      6,745.65 ns |      24.997 ns |      23.382 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 16KB         |      7,232.92 ns |      24.665 ns |      23.072 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      7,511.53 ns |      31.164 ns |      29.151 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |     13,291.08 ns |       4.116 ns |       3.214 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     95,206.66 ns |     305.773 ns |     286.020 ns |     840 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |     12,133.71 ns |      50.988 ns |      47.694 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |     25,726.93 ns |     107.122 ns |      94.960 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64KB         |     27,122.85 ns |      95.224 ns |      89.072 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |     27,422.75 ns |      66.498 ns |      62.202 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |     29,896.58 ns |     111.497 ns |     104.294 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     53,282.00 ns |      12.601 ns |      11.787 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |    381,115.80 ns |   1,106.413 ns |   1,034.939 ns |    3528 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |     14,745.61 ns |      33.102 ns |      29.344 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |     40,114.90 ns |     310.516 ns |     290.457 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |     42,954.07 ns |     226.328 ns |     211.707 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100000B      |     43,332.03 ns |     175.516 ns |     164.178 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |     46,645.72 ns |     248.911 ns |     232.831 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     81,454.89 ns |      23.497 ns |      21.979 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |    586,649.47 ns |   3,746.038 ns |   3,504.046 ns |    5432 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |     15,668.64 ns |     272.679 ns |     255.064 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |     52,113.97 ns |     232.434 ns |     217.419 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128KB        |     55,257.89 ns |     139.792 ns |     123.922 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |     55,335.12 ns |     265.695 ns |     248.531 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |     60,506.60 ns |     233.969 ns |     218.855 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |    107,349.99 ns |     270.873 ns |     253.375 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |    771,503.89 ns |   3,207.249 ns |   3,000.062 ns |    7112 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     66,523.37 ns |     309.948 ns |     274.761 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |    397,049.96 ns |   1,424.926 ns |   1,332.877 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1MB          |    422,002.47 ns |   1,486.276 ns |   1,390.263 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |    422,185.49 ns |   1,699.442 ns |   1,589.659 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |    460,256.25 ns |   1,346.161 ns |   1,193.337 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |    814,627.65 ns |     222.674 ns |     197.394 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  5,861,759.63 ns |  16,064.995 ns |  15,027.206 ns |   54656 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |    644,350.52 ns |   4,442.601 ns |   4,155.612 ns |     135 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |  3,965,641.91 ns |  17,560.443 ns |  16,426.049 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10MB         |  4,214,612.35 ns |  17,760.952 ns |  16,613.606 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |  4,251,482.98 ns |  26,835.079 ns |  25,101.549 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |  4,591,619.74 ns |  13,606.805 ns |  12,062.078 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  8,154,235.40 ns |   5,783.607 ns |   5,127.017 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 58,628,758.28 ns | 182,219.898 ns | 161,533.193 ns |  546840 B |