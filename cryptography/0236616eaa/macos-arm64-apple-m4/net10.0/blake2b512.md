| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      91.58 ns |     0.192 ns |     0.180 ns |      91.61 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      96.97 ns |     0.129 ns |     0.120 ns |      96.98 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     126.32 ns |     0.127 ns |     0.113 ns |     126.36 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     172.90 ns |     1.566 ns |     1.389 ns |     173.15 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     692.29 ns |     0.615 ns |     0.575 ns |     692.13 ns |    1216 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     187.58 ns |     0.043 ns |     0.036 ns |     187.58 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     267.27 ns |     5.364 ns |    14.953 ns |     273.18 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     374.38 ns |     3.107 ns |     2.906 ns |     373.62 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     803.97 ns |     0.495 ns |     0.463 ns |     803.77 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   6,138.75 ns |     4.835 ns |     4.287 ns |   6,139.39 ns |    1232 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |   3,079.74 ns |     1.527 ns |     1.428 ns |   3,079.43 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |   3,498.88 ns |     2.072 ns |     1.618 ns |   3,498.65 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |   4,109.72 ns |     5.267 ns |     4.669 ns |   4,109.79 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   7,686.15 ns |    23.391 ns |    20.736 ns |   7,680.35 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |  21,104.32 ns |    12.183 ns |    10.174 ns |  21,105.47 ns |    2112 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     736.04 ns |    11.764 ns |     9.823 ns |     733.89 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   3,942.86 ns |     3.658 ns |     3.242 ns |   3,941.28 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |   4,613.11 ns |     7.775 ns |     6.892 ns |   4,615.82 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   8,643.63 ns |     4.563 ns |     3.811 ns |   8,642.98 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |  24,007.19 ns |    16.709 ns |    14.812 ns |  24,007.87 ns |    2120 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,174.38 ns |    24.229 ns |    20.232 ns |   5,165.91 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,916.10 ns |     0.690 ns |     0.645 ns |   5,916.12 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,839.37 ns |    52.073 ns |    48.710 ns |   6,803.44 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  11,973.69 ns |    29.338 ns |    26.008 ns |  11,966.27 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  33,904.35 ns |    76.329 ns |    71.398 ns |  33,910.55 ns |    9280 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,535.05 ns |    25.172 ns |    23.546 ns |  82,535.58 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  93,596.95 ns |   266.859 ns |   249.620 ns |  93,687.36 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 108,633.13 ns |    48.444 ns |    45.315 ns | 108,645.23 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 191,423.91 ns |    26.802 ns |    20.925 ns | 191,418.27 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 542,883.88 ns | 3,016.114 ns | 2,821.275 ns | 541,036.01 ns |  132188 B |