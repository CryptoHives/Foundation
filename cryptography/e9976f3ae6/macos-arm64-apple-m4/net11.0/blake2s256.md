| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         76.20 ns |      0.356 ns |      0.333 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         81.78 ns |      0.319 ns |      0.299 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        105.64 ns |      0.307 ns |      0.287 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 4B           |        203.33 ns |      0.585 ns |      0.547 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         75.25 ns |      0.217 ns |      0.192 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         79.47 ns |      0.323 ns |      0.302 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        102.62 ns |      0.258 ns |      0.242 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64B          |        203.21 ns |      0.531 ns |      0.496 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        142.23 ns |      0.757 ns |      0.708 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        158.24 ns |      0.506 ns |      0.395 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        189.01 ns |      0.491 ns |      0.460 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 65B          |        407.06 ns |      0.876 ns |      0.819 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        142.13 ns |      0.521 ns |      0.488 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        157.82 ns |      0.701 ns |      0.656 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        190.24 ns |      0.639 ns |      0.598 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |        407.07 ns |      1.134 ns |      1.061 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        210.19 ns |      0.654 ns |      0.612 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        235.95 ns |      0.688 ns |      0.644 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        277.42 ns |      0.900 ns |      0.842 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 129B         |        610.81 ns |      1.344 ns |      1.258 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,094.44 ns |      6.412 ns |      5.998 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,236.13 ns |      6.484 ns |      6.065 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,427.43 ns |      4.268 ns |      3.992 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |      3,264.93 ns |      8.222 ns |      7.691 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,163.19 ns |      4.635 ns |      4.336 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,313.35 ns |      6.344 ns |      5.934 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,514.60 ns |      2.980 ns |      2.788 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |      3,459.40 ns |     18.832 ns |     17.615 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |      8,666.20 ns |     40.345 ns |     37.739 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |      9,870.14 ns |     77.845 ns |     72.816 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     11,282.09 ns |     31.601 ns |     29.560 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |     26,121.23 ns |     70.458 ns |     65.907 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     69,195.60 ns |    505.795 ns |    473.121 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     78,857.48 ns |    639.210 ns |    597.917 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     89,967.43 ns |    239.593 ns |    224.115 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64KB         |    209,033.80 ns |    554.952 ns |    519.103 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    138,171.83 ns |    711.667 ns |    665.693 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    157,699.90 ns |    522.751 ns |    488.982 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    184,240.63 ns |  1,964.324 ns |  1,837.430 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        |    417,719.08 ns |  1,434.814 ns |  1,342.126 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,053,664.09 ns |  6,609.922 ns |  6,182.925 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,206,107.92 ns |  9,450.607 ns |  8,840.104 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,401,844.08 ns | 10,155.985 ns |  9,499.915 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1MB          |  3,190,042.96 ns |  6,800.908 ns |  6,361.574 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 10,502,633.09 ns | 34,544.105 ns | 30,622.449 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 11,990,750.42 ns | 38,266.377 ns | 33,922.146 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 13,653,055.08 ns | 11,525.292 ns | 10,780.766 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 10MB         | 31,891,043.23 ns | 42,363.791 ns | 39,627.116 ns |         - |