| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     513.5 ns |     0.87 ns |     0.78 ns |     513.6 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  30,054.6 ns |   597.51 ns | 1,752.40 ns |  31,194.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     660.9 ns |     2.32 ns |     2.17 ns |     661.8 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  30,342.5 ns |   601.60 ns | 1,626.46 ns |  31,359.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,565.9 ns |     5.68 ns |     5.31 ns |   1,566.7 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  31,423.1 ns |   910.22 ns | 2,683.79 ns |  32,714.1 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,566.0 ns |     5.64 ns |     5.28 ns |   1,566.2 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  31,583.9 ns |   882.70 ns | 2,602.66 ns |  32,759.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |   9,520.0 ns |    26.27 ns |    24.57 ns |   9,528.6 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  43,061.8 ns |   860.85 ns | 1,853.07 ns |  44,138.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 146,159.9 ns |   498.55 ns |   466.34 ns | 146,080.5 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 255,804.8 ns | 2,411.49 ns | 2,255.71 ns | 256,425.2 ns |     128 B |