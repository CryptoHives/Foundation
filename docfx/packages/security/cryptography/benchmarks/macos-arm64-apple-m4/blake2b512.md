| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      91.83 ns |     0.609 ns |     0.508 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      95.61 ns |     0.314 ns |     0.293 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     128.95 ns |     0.251 ns |     0.222 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     175.13 ns |     2.369 ns |     2.216 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     602.52 ns |     3.409 ns |     3.189 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     168.54 ns |     0.427 ns |     0.379 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     186.32 ns |     0.386 ns |     0.361 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     234.90 ns |     0.203 ns |     0.180 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     359.18 ns |     3.128 ns |     2.926 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,103.62 ns |     5.495 ns |     5.140 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     643.30 ns |     3.045 ns |     2.848 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     724.40 ns |     2.515 ns |     2.229 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     873.38 ns |     0.500 ns |     0.443 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,482.35 ns |     3.817 ns |     3.571 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,728.16 ns |     8.684 ns |     7.699 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     731.73 ns |     1.548 ns |     1.448 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     815.15 ns |     2.597 ns |     2.430 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     976.76 ns |     1.149 ns |     1.019 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,668.03 ns |     5.068 ns |     4.492 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   4,275.44 ns |    24.982 ns |    23.368 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,147.42 ns |     3.068 ns |     2.720 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,851.02 ns |    15.999 ns |    14.182 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,794.57 ns |     3.258 ns |     2.888 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  11,965.72 ns |     7.008 ns |     5.852 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  29,267.41 ns |    80.778 ns |    75.560 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,466.15 ns |    67.661 ns |    59.980 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  93,817.57 ns |   225.412 ns |   210.850 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 108,382.96 ns |    18.711 ns |    17.502 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 191,339.40 ns |    23.917 ns |    18.673 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 475,078.70 ns | 1,666.854 ns | 1,559.176 ns |  132188 B |