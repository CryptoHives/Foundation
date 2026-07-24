| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.653 μs | 0.0008 μs | 0.0007 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.086 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.116 μs | 0.0011 μs | 0.0010 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   8.936 μs | 0.0197 μs | 0.0184 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.733 μs | 0.0115 μs | 0.0107 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.282 μs | 0.0033 μs | 0.0031 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.848 μs | 0.0007 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.862 μs | 0.0013 μs | 0.0010 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |  12.538 μs | 0.0279 μs | 0.0233 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.815 μs | 0.0273 μs | 0.0255 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.326 μs | 0.0047 μs | 0.0037 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.897 μs | 0.0034 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.930 μs | 0.0036 μs | 0.0034 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |  41.831 μs | 0.1596 μs | 0.1493 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  54.329 μs | 0.0913 μs | 0.0854 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.736 μs | 0.0481 μs | 0.0426 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.239 μs | 0.0483 μs | 0.0403 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 113.053 μs | 0.0947 μs | 0.0885 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 543.476 μs | 2.2610 μs | 2.1150 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 694.906 μs | 2.4130 μs | 2.2571 μs |      56 B |