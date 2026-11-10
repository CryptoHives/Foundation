| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.155 μs | 0.0011 μs | 0.0009 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |     2.247 μs | 0.0009 μs | 0.0009 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128B         |     2.296 μs | 0.0015 μs | 0.0014 μs |  15,959 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |     2.400 μs | 0.0008 μs | 0.0007 μs |  25,386 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |     3.154 μs | 0.0017 μs | 0.0016 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     4.193 μs | 0.0114 μs | 0.0107 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    23.735 μs | 0.0239 μs | 0.0212 μs |  28,848 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 1KB          |     2.580 μs | 0.0018 μs | 0.0016 μs |  15,936 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |     2.606 μs | 0.0021 μs | 0.0019 μs |  25,160 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.018 μs | 0.0014 μs | 0.0012 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |     3.129 μs | 0.0012 μs | 0.0010 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |     4.154 μs | 0.0025 μs | 0.0023 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |     5.898 μs | 0.0100 μs | 0.0093 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    33.527 μs | 0.0287 μs | 0.0268 μs |  29,066 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |     5.983 μs | 0.0119 μs | 0.0111 μs |  25,138 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 8KB          |     6.299 μs | 0.0063 μs | 0.0056 μs |  15,936 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.889 μs | 0.0049 μs | 0.0044 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |    10.266 μs | 0.0061 μs | 0.0057 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |    12.541 μs | 0.0114 μs | 0.0106 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    19.187 μs | 0.0417 μs | 0.0370 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |   112.056 μs | 0.0609 μs | 0.0540 μs |  28,825 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |    55.254 μs | 0.2156 μs | 0.2017 μs |  25,149 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128KB        |    65.639 μs | 0.1330 μs | 0.1244 μs |  15,936 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   126.894 μs | 0.1249 μs | 0.1169 μs |   7,932 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |   132.525 μs | 0.0675 μs | 0.0563 μs |     979 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        |   152.423 μs | 0.1720 μs | 0.1609 μs |   7,007 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   246.103 μs | 0.4271 μs | 0.3995 μs |  15,849 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,445.030 μs | 0.9020 μs | 0.8438 μs |  28,829 B |      56 B |