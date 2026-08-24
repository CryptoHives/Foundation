| Description                                           | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     2.919 μs |  0.0049 μs |  0.0044 μs |     2.918 μs |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |   153.823 μs |  3.9523 μs | 11.3398 μs |   156.958 μs |     128 B |
|                                                       |              |              |            |            |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     3.612 μs |  0.0039 μs |  0.0035 μs |     3.612 μs |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |   154.826 μs |  3.7385 μs | 10.8461 μs |   157.699 μs |     128 B |
|                                                       |              |              |            |            |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |     8.221 μs |  0.0031 μs |  0.0027 μs |     8.220 μs |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |   161.679 μs |  3.6264 μs | 10.1688 μs |   164.638 μs |     128 B |
|                                                       |              |              |            |            |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |     8.210 μs |  0.0088 μs |  0.0078 μs |     8.209 μs |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |   161.583 μs |  3.6619 μs | 10.3285 μs |   164.447 μs |     128 B |
|                                                       |              |              |            |            |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |    48.384 μs |  0.2604 μs |  0.2033 μs |    48.285 μs |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |   219.201 μs |  4.1315 μs |  8.0582 μs |   221.894 μs |     128 B |
|                                                       |              |              |            |            |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        |   784.455 μs |  0.8764 μs |  0.7769 μs |   784.431 μs |  263304 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 1,220.044 μs | 14.6139 μs | 13.6699 μs | 1,219.431 μs |     128 B |