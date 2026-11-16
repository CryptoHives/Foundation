| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Median       | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.162 μs | 0.0022 μs | 0.0042 μs |     2.161 μs |   8,086 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128B         |     2.240 μs | 0.0028 μs | 0.0050 μs |     2.239 μs |  14,685 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |     2.244 μs | 0.0041 μs | 0.0076 μs |     2.242 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |     2.432 μs | 0.0269 μs | 0.0506 μs |     2.404 μs |  25,386 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |     3.187 μs | 0.0520 μs | 0.0964 μs |     3.126 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     4.157 μs | 0.0160 μs | 0.0304 μs |     4.161 μs |  16,003 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    24.206 μs | 0.3465 μs | 0.6423 μs |    23.912 μs |  28,854 B |      56 B |
|                                             |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 1KB          |     2.459 μs | 0.0072 μs | 0.0134 μs |     2.464 μs |  14,662 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |     2.619 μs | 0.0155 μs | 0.0290 μs |     2.605 μs |  25,140 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.023 μs | 0.0024 μs | 0.0046 μs |     3.022 μs |   8,086 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |     3.129 μs | 0.0041 μs | 0.0077 μs |     3.125 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |     4.147 μs | 0.0036 μs | 0.0067 μs |     4.149 μs |   7,009 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |     5.847 μs | 0.0147 μs | 0.0276 μs |     5.852 μs |  16,003 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    33.629 μs | 0.0615 μs | 0.1125 μs |    33.586 μs |  29,067 B |      56 B |
|                                             |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 8KB          |     5.138 μs | 0.0234 μs | 0.0446 μs |     5.117 μs |  14,662 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |     5.813 μs | 0.1336 μs | 0.2476 μs |     5.968 μs |  25,160 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.892 μs | 0.0048 μs | 0.0092 μs |     9.893 μs |   8,086 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |    10.268 μs | 0.0062 μs | 0.0114 μs |    10.264 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |    12.285 μs | 0.0151 μs | 0.0284 μs |    12.281 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    19.117 μs | 0.0315 μs | 0.0599 μs |    19.128 μs |  16,003 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |   111.144 μs | 0.0582 μs | 0.1093 μs |   111.104 μs |  28,835 B |      56 B |
|                                             |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128KB        |    53.614 μs | 0.9959 μs | 1.8704 μs |    52.968 μs |  14,662 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |    55.200 μs | 0.1570 μs | 0.2988 μs |    55.115 μs |  25,138 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   126.816 μs | 0.0977 μs | 0.1859 μs |   126.826 μs |   8,086 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |   132.464 μs | 0.0577 μs | 0.1055 μs |   132.476 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        |   151.886 μs | 0.1870 μs | 0.3559 μs |   151.960 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   245.254 μs | 0.4656 μs | 0.8858 μs |   245.135 μs |  16,003 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,442.782 μs | 0.5342 μs | 0.9768 μs | 1,442.635 μs |  28,829 B |      56 B |