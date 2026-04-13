| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128B         |      85.47 ns |     1.538 ns |     2.053 ns |      85.20 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      96.29 ns |     0.906 ns |     0.847 ns |      96.14 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     101.04 ns |     1.403 ns |     1.172 ns |     101.22 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     139.85 ns |     2.753 ns |     4.523 ns |     138.36 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     509.27 ns |     9.791 ns |    25.098 ns |     499.30 ns |    1120 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 137B         |     165.65 ns |     1.030 ns |     0.913 ns |     165.73 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     178.43 ns |     1.034 ns |     0.967 ns |     178.70 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     186.74 ns |     1.506 ns |     1.409 ns |     187.15 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     260.76 ns |     5.091 ns |     6.969 ns |     257.22 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |     944.07 ns |    18.274 ns |    22.442 ns |     948.13 ns |    1136 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1KB          |     626.23 ns |     3.210 ns |     2.846 ns |     626.17 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     652.27 ns |     7.340 ns |     8.453 ns |     649.58 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     715.20 ns |     2.431 ns |     2.030 ns |     714.83 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     987.90 ns |    18.899 ns |    19.408 ns |     987.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,111.33 ns |    60.015 ns |    56.138 ns |   3,094.60 ns |    2016 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1025B        |     713.70 ns |     4.604 ns |     4.081 ns |     711.78 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     731.50 ns |     2.329 ns |     1.945 ns |     731.32 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     804.56 ns |     4.233 ns |     3.753 ns |     805.39 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   1,089.92 ns |    13.565 ns |    11.328 ns |   1,086.66 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   3,545.57 ns |    55.962 ns |    52.347 ns |   3,533.60 ns |    2024 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 8KB          |   4,979.46 ns |    24.289 ns |    21.532 ns |   4,985.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,082.36 ns |    30.454 ns |    28.486 ns |   5,075.46 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   5,607.91 ns |    28.908 ns |    27.041 ns |   5,595.83 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   7,684.93 ns |   136.607 ns |   127.782 ns |   7,636.75 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  24,054.70 ns |   463.464 ns |   475.943 ns |  23,945.83 ns |    9184 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128KB        |  79,613.89 ns |   630.019 ns |   589.320 ns |  79,359.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  80,960.21 ns |   482.480 ns |   451.312 ns |  80,977.53 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        |  89,005.77 ns |   487.532 ns |   432.184 ns |  88,819.73 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 122,883.31 ns | 2,280.342 ns | 2,133.033 ns | 121,899.84 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 411,394.62 ns | 7,990.059 ns | 9,511.597 ns | 408,785.89 ns |  132078 B |