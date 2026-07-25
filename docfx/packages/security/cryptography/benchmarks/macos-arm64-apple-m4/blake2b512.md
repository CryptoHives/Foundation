| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      91.55 ns |     0.136 ns |     0.127 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      97.15 ns |     0.038 ns |     0.036 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     128.82 ns |     0.110 ns |     0.103 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     175.27 ns |     3.424 ns |     3.664 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     614.05 ns |     2.702 ns |     2.528 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     169.85 ns |     0.071 ns |     0.067 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     187.67 ns |     0.245 ns |     0.229 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     234.57 ns |     0.152 ns |     0.142 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     358.89 ns |     3.879 ns |     3.628 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,126.33 ns |     2.826 ns |     2.643 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     652.77 ns |     0.201 ns |     0.188 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     740.97 ns |     0.429 ns |     0.401 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     873.42 ns |     0.208 ns |     0.174 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,482.93 ns |     3.797 ns |     3.552 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,831.08 ns |    17.872 ns |    15.843 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     734.23 ns |     0.235 ns |     0.220 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     833.92 ns |     0.745 ns |     0.697 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     977.37 ns |     0.891 ns |     0.790 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,669.00 ns |     4.344 ns |     4.064 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   4,347.14 ns |    13.297 ns |    12.438 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,165.34 ns |     2.845 ns |     2.661 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,900.89 ns |     4.463 ns |     4.175 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,801.33 ns |     3.801 ns |     3.369 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  11,947.03 ns |     3.470 ns |     3.246 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  29,425.38 ns |    68.039 ns |    63.644 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,507.34 ns |    45.378 ns |    40.226 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  94,388.40 ns |    62.834 ns |    58.775 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 108,425.24 ns |    80.851 ns |    75.628 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 191,983.55 ns |    32.314 ns |    28.646 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 477,355.95 ns | 1,189.806 ns | 1,054.732 ns |  132188 B |