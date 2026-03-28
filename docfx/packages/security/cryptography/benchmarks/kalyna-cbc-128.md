| Description                             | TestDataSize | Mean           | Error         | StdDev        | Median         | Allocated |
|---------------------------------------- |------------- |---------------:|--------------:|--------------:|---------------:|----------:|
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |       2.554 μs |     0.0274 μs |     0.0229 μs |       2.551 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     313.624 μs |     6.0779 μs |     6.7556 μs |     312.578 μs |         - |
|                                         |              |                |               |               |                |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |       1.439 μs |     0.0053 μs |     0.0047 μs |       1.439 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     273.587 μs |     1.5452 μs |     1.4454 μs |     274.005 μs |         - |
|                                         |              |                |               |               |                |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |      15.554 μs |     0.1080 μs |     0.0958 μs |      15.556 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |   2,425.932 μs |    19.7768 μs |    18.4993 μs |   2,424.652 μs |         - |
|                                         |              |                |               |               |                |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |       7.624 μs |     0.0449 μs |     0.0420 μs |       7.611 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |   2,129.588 μs |    12.6437 μs |    11.8269 μs |   2,128.983 μs |         - |
|                                         |              |                |               |               |                |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |     119.688 μs |     0.9044 μs |     0.8018 μs |     119.902 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |  18,881.755 μs |   186.3611 μs |   174.3223 μs |  18,856.978 μs |         - |
|                                         |              |                |               |               |                |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |      60.394 μs |     1.6230 μs |     4.4973 μs |      58.786 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |  17,198.652 μs |    69.9829 μs |    62.0380 μs |  17,211.161 μs |         - |
|                                         |              |                |               |               |                |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   1,891.580 μs |     8.5599 μs |     7.5881 μs |   1,890.817 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 289,273.723 μs | 3,104.5897 μs | 2,904.0351 μs | 290,057.250 μs |    6168 B |
|                                         |              |                |               |               |                |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |     895.870 μs |     4.3627 μs |     3.6431 μs |     894.586 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 279,692.208 μs | 1,716.7011 μs | 1,908.1087 μs | 279,164.850 μs |         - |