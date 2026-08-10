| Description                                  | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|--------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |        99.67 ns |     1.253 ns |     1.172 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128B         |       153.56 ns |     0.642 ns |     0.601 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |       593.99 ns |     1.881 ns |     1.760 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     1,280.53 ns |     2.208 ns |     1.957 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |       150.99 ns |     0.547 ns |     0.485 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 137B         |       221.90 ns |     0.757 ns |     0.671 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |       878.13 ns |     2.261 ns |     2.004 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |     1,935.18 ns |     4.220 ns |     3.741 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |       753.39 ns |     5.106 ns |     5.015 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     1,075.63 ns |     3.015 ns |     2.672 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |     4,578.79 ns |    18.484 ns |    15.435 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |     9,675.73 ns |    23.346 ns |    19.495 ns |         - |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |       850.73 ns |     2.275 ns |     1.776 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 1025B        |     1,229.09 ns |     3.371 ns |     3.153 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |     5,197.38 ns |    22.377 ns |    20.931 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |    10,760.39 ns |    21.098 ns |    17.618 ns |      56 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |     1,171.02 ns |     2.191 ns |     1.942 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 8KB          |    10,147.28 ns |   115.494 ns |   108.033 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |    38,745.23 ns |   133.595 ns |   111.558 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |    81,347.98 ns |   228.671 ns |   202.711 ns |     392 B |
|                                              |              |                 |              |              |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |    14,404.03 ns |    89.875 ns |    70.169 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   165,900.83 ns |   375.950 ns |   333.270 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |   623,212.95 ns | 1,899.429 ns | 1,683.794 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 1,370,159.36 ns | 2,330.505 ns | 2,179.956 ns |    7112 B |