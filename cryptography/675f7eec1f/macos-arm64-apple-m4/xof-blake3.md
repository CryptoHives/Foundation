| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.655 μs | 0.0037 μs | 0.0034 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.988 μs | 0.0050 μs | 0.0045 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.992 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.089 μs | 0.0031 μs | 0.0029 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.120 μs | 0.0024 μs | 0.0023 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.813 μs | 0.0093 μs | 0.0087 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.289 μs | 0.0012 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.459 μs | 0.0076 μs | 0.0067 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.740 μs | 0.0077 μs | 0.0072 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.854 μs | 0.0010 μs | 0.0009 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.863 μs | 0.0092 μs | 0.0086 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.927 μs | 0.0168 μs | 0.0149 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.704 μs | 0.0144 μs | 0.0134 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.339 μs | 0.0078 μs | 0.0073 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.764 μs | 0.0065 μs | 0.0061 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.906 μs | 0.0243 μs | 0.0227 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.921 μs | 0.0069 μs | 0.0061 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  54.701 μs | 0.1391 μs | 0.1301 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  61.876 μs | 0.2752 μs | 0.2574 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.762 μs | 0.2988 μs | 0.2795 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.922 μs | 0.0615 μs | 0.0575 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.390 μs | 0.2887 μs | 0.2700 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.937 μs | 0.1307 μs | 0.1223 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 700.281 μs | 1.6541 μs | 1.5472 μs |      56 B |