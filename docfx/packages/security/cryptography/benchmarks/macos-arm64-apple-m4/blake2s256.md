| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     141.8 ns |   0.06 ns |   0.06 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     157.0 ns |   0.60 ns |   0.56 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     197.6 ns |   0.34 ns |   0.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     387.8 ns |   4.52 ns |   4.23 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     209.8 ns |   0.09 ns |   0.08 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     233.8 ns |   0.27 ns |   0.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     286.4 ns |   0.44 ns |   0.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     594.6 ns |   6.43 ns |   6.01 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,091.5 ns |   0.63 ns |   0.56 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,237.5 ns |   3.10 ns |   2.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,456.0 ns |   2.12 ns |   1.98 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,222.4 ns |   7.72 ns |   7.22 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,158.8 ns |   0.80 ns |   0.67 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,315.9 ns |   3.90 ns |   3.46 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,542.7 ns |   2.05 ns |   1.82 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,425.8 ns |   7.00 ns |   6.54 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,649.4 ns |  10.81 ns |  10.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,867.2 ns |  32.02 ns |  29.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,468.2 ns |  12.07 ns |  11.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  25,900.4 ns |   5.30 ns |   4.13 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 138,001.5 ns |  77.88 ns |  65.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 157,959.0 ns | 494.26 ns | 462.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 183,363.1 ns | 288.99 ns | 270.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 414,645.1 ns |  46.38 ns |  38.73 ns |         - |