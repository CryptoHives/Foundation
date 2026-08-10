| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     251.5 ns |     1.46 ns |     1.36 ns |     251.0 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     321.7 ns |     1.69 ns |     1.32 ns |     321.6 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     328.9 ns |     0.87 ns |     0.77 ns |     328.9 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     333.2 ns |     1.30 ns |     1.22 ns |     333.5 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     503.1 ns |     1.70 ns |     1.59 ns |     502.7 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     633.6 ns |     2.98 ns |     2.79 ns |     632.9 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     649.5 ns |     2.77 ns |     2.59 ns |     649.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     665.7 ns |     2.20 ns |     1.72 ns |     665.6 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,658.1 ns |     2.60 ns |     2.31 ns |   1,658.4 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,223.7 ns |     7.68 ns |     6.42 ns |   2,221.8 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,283.6 ns |     5.09 ns |     4.76 ns |   2,283.3 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,467.7 ns |    13.88 ns |    12.30 ns |   2,463.0 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,662.9 ns |     4.08 ns |     3.18 ns |   1,664.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,218.4 ns |     3.70 ns |     2.89 ns |   2,218.5 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,280.4 ns |     7.44 ns |     6.59 ns |   2,279.6 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,461.9 ns |     6.97 ns |     6.52 ns |   2,463.2 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,921.4 ns |   255.28 ns |   404.90 ns |  12,917.4 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  17,917.9 ns |   482.23 ns | 1,421.87 ns |  17,288.6 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  19,193.8 ns |   487.71 ns | 1,430.37 ns |  19,893.6 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  19,456.3 ns |   387.39 ns |   866.45 ns |  19,105.4 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 190,140.8 ns |   875.83 ns |   819.26 ns | 189,943.2 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 257,335.9 ns |   283.27 ns |   236.54 ns | 257,355.4 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 265,191.6 ns | 1,847.11 ns | 1,542.42 ns | 264,595.1 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 293,843.4 ns | 1,587.37 ns | 1,484.83 ns | 293,312.5 ns |         - |