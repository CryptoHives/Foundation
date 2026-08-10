| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.654 μs | 0.0042 μs | 0.0039 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.988 μs | 0.0031 μs | 0.0029 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.990 μs | 0.0012 μs | 0.0011 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.087 μs | 0.0057 μs | 0.0051 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.120 μs | 0.0014 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.769 μs | 0.0129 μs | 0.0115 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.288 μs | 0.0020 μs | 0.0019 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.455 μs | 0.0064 μs | 0.0060 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.741 μs | 0.0065 μs | 0.0060 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.852 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.867 μs | 0.0072 μs | 0.0064 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.873 μs | 0.0482 μs | 0.0451 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.691 μs | 0.0187 μs | 0.0175 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.342 μs | 0.0064 μs | 0.0060 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.761 μs | 0.0069 μs | 0.0064 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.917 μs | 0.0059 μs | 0.0049 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.920 μs | 0.0074 μs | 0.0069 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  54.650 μs | 0.0629 μs | 0.0588 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  61.678 μs | 0.2742 μs | 0.2431 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.834 μs | 0.2230 μs | 0.2086 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.818 μs | 0.2590 μs | 0.2422 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.443 μs | 0.1272 μs | 0.1063 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.880 μs | 0.0618 μs | 0.0548 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 697.795 μs | 2.2550 μs | 2.1094 μs |      56 B |