| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      91.73 ns |     1.188 ns |     1.111 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      98.00 ns |     1.263 ns |     1.181 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     124.36 ns |     0.208 ns |     0.163 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     173.14 ns |     2.140 ns |     2.002 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     609.16 ns |    11.262 ns |    10.534 ns |    1120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     171.18 ns |     2.384 ns |     2.230 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     190.79 ns |     2.514 ns |     2.352 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     232.60 ns |     3.275 ns |     3.063 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     361.23 ns |     5.118 ns |     4.537 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,120.99 ns |     2.672 ns |     2.086 ns |    1136 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     662.70 ns |     9.357 ns |     8.753 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     748.97 ns |     9.238 ns |     8.641 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     879.20 ns |    11.721 ns |    10.963 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,498.60 ns |    16.802 ns |    15.717 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,873.04 ns |    19.390 ns |    15.138 ns |    2016 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     742.81 ns |     9.569 ns |     8.951 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     844.20 ns |    10.255 ns |     9.592 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     975.60 ns |     2.312 ns |     1.805 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,692.25 ns |    19.487 ns |    18.228 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   4,394.08 ns |    19.486 ns |    15.214 ns |    2024 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,214.65 ns |    76.121 ns |    67.479 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,981.60 ns |    75.777 ns |    70.881 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,883.03 ns |    97.520 ns |    91.220 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  12,090.74 ns |   119.334 ns |   111.625 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  30,139.43 ns |   411.104 ns |   384.547 ns |    9184 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  83,248.36 ns |   959.220 ns |   800.992 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  95,745.70 ns | 1,249.698 ns | 1,168.969 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 109,885.57 ns | 1,525.872 ns | 1,427.301 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 194,497.76 ns | 2,675.929 ns | 2,503.066 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 483,533.51 ns | 1,683.783 ns | 1,314.587 ns |  132092 B |