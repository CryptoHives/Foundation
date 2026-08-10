| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      84.23 ns |     0.311 ns |     0.275 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      96.53 ns |     0.801 ns |     0.669 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     103.98 ns |     0.087 ns |     0.077 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     131.10 ns |     0.273 ns |     0.255 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     527.25 ns |     1.777 ns |     1.575 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     167.24 ns |     0.465 ns |     0.435 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     177.10 ns |     0.465 ns |     0.413 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     188.65 ns |     2.842 ns |     2.659 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     255.19 ns |     0.325 ns |     0.288 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     964.47 ns |    12.787 ns |    12.559 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     628.69 ns |     1.471 ns |     1.376 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     652.03 ns |     2.333 ns |     1.948 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     723.26 ns |     2.315 ns |     2.165 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     993.44 ns |     2.012 ns |     1.784 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,140.25 ns |     3.217 ns |     3.009 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     713.78 ns |     1.764 ns |     1.564 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     731.29 ns |     1.425 ns |     1.263 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     808.88 ns |     1.479 ns |     1.155 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,113.48 ns |     2.229 ns |     2.085 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,575.18 ns |     8.281 ns |     7.341 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   4,976.92 ns |    12.447 ns |     9.718 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,085.63 ns |    14.647 ns |    12.231 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,626.45 ns |    15.718 ns |    14.703 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,814.55 ns |     9.823 ns |     8.708 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,996.70 ns |    26.870 ns |    23.820 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  79,745.52 ns |   243.751 ns |   228.005 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  81,102.31 ns |   159.364 ns |   141.272 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  89,680.41 ns |   288.691 ns |   255.917 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 126,209.10 ns |   187.828 ns |   166.505 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 412,690.57 ns | 1,719.619 ns | 1,435.960 ns |  132174 B |