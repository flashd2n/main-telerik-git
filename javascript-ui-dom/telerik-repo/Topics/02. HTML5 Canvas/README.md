<!-- attr: { hasScriptWrapper:true, id:"title" class:"slide-title" } -->
<h1>The HTML5 Canvas</h1>
<h2>Low-level graphics in the Web</h2>
<aside class="signature">
    <p class="signature-course">JavaScript DOM & UI</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="https://telerikacademy.com" class="signature-link">https://telerikacademy.com</a>
</aside>

<!-- Table of Contents -->
<!-- attr: { hasScriptWrapper:true, id:"table-of-contents" data-markdown style:"font-size:40px" } -->
# Table of Contents
- Overview and usage of the canvas
- Drawing shapes
    - Rectangles, arcs and ellipses
    - Lines, paths and Bézier curves
- Drawing Text
- Per-pixel manipulations
- Canvas styles
    - `fillColor` and `strokeColor`
    - Gradients, patterns and shadows
- Transformations
    - Save and restore context state
    - Translate

<!-- The HTML5 Canvas -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"html5-canvas" data-markdown class:"slide-section" } -->
# The HTML5 Canvas
## The way of the graphics in web

<!-- attr: { hasScriptWrapper:true } -->
# The HTML5 Canvas
- The Canvas is the way to draw in the browser
    - Uses JavaScript for the drawing
    - Enables high-performance drawing
- The Canvas is part of the HTML5 specification
    - Supported in most browsers
        - Both desktop and mobile

<!-- attr: { hasScriptWrapper:true } -->
# Using the Canvas
- The Canvas is a rectangular sheet
    - All the drawing is done inside this sheet
- The canvas consists of:
    - `<canvas>` HTML element
    - JavaScript API for the drawing

    <canvas id="the-canvas" width="100" height="100" />

<p></p>

    var canvas = document.getElementById('the-canvas');
    var canvasCtx = canvas.getContext('2d');
    canvasCtx.fillRect(10, 10, 30, 30);

- Set width and height <!-- .element: style="top:48%; left: 70%" class="fragment balloon" -->

<!-- attr: { hasScriptWrapper:true } -->
# The HTML5 Canvas Context
- The canvas HTML element provides many ways for drawing
    - Rectangular 2d drawing
    - 3d drawing
    - WebGL drawing
- HTML5 provides APIs for all these types of drawing
 - The way to use a specific canvas API is to get the corresponding context

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Using the HTML5 Canvas
## Live Demo

<!-- Drawing Shapes -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"drawing-shapes" data-markdown class:"slide-section" } -->
# Drawing Shapes
## Rects, Arcs, Ellipses

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Shapes
- The Canvas provides ways to draw all kinds of shapes
    - Rects, arcs, ellipses, lines, etc…
- Each of these shapes can be either
    - Drawn in full color (i.e. filled)
    - Drawn only their border (i.e. stroked)

    var canvas = document.getElementById('the-canvas');
    var canvasCtx = canvas.getContext('2d');
    canvasCtx.fillRect(10, 10, 25, 25);
    canvasCtx.strokeRect(10, 10, 25, 25);

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Rects
- Drawing rects is the simplest way to draw with the canvas
    - Build-in functionality
    - `context.fillRect (x, y, width, height)` <!-- .element: style="font-size: 0.9em" -->
        - Creates a rectangular shape at position (x, y) from the top left corner of the canvas
        - The shape is drawn in full color
    - `context.strokeRect (x, y, width, height)` <!-- .element: style="font-size: 0.9em" -->
        - Same as fillRect
        - Only the border of the shape is drawn

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Rects: Example
- Drawing a rectangle filled with light blue and with dark blue border

<pre><code><canvas id="rects-canvas"> </canvas></code></pre>
<pre><code>var canvas = document.getElementById('rects-canvas'),
ctx = canvas.getContext('2d');
ctx.fillStyle = 'rgb(107, 187, 201)';
ctx.strokeStyle = 'rgb(2, 55, 155)';
ctx.fillRect(20, 20, 140, 90);
ctx.strokeRect(20, 20, 140, 90);</code></pre>

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Drawing Rects
## Live Demo

<!-- Canvas Paths -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"canvas-paths" data-markdown class:"slide-section" } -->
# Canvas Paths
## Drawing arcs and lines

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Paths
- The Canvas can do much more than just drawing rectangles
    - Bezier curves, ellipses, arcs
    - Much of the power of the Canvas comes from the path
- The path is just a set of connected dots
    - Depending on the method used, the dots can be connected using straight line or curve

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Paths (2)
- The canvas context has methods for paths:
    - beginPath()
        - Starts path
    - `moveTo(x, y)`
        - Changes the position of the path marker
    - `lineTo(x, y)`
        - Draws a straight line from the position of the path marker to position (x, y)
    - `fill()` / `stroke()`
        - Fills or strokes the path

<!-- attr: { hasScriptWrapper:true, style:"font-size: 45px" } -->
# How the Canvas Works?
- The canvas only marks dots on the canvas sheet
    - And remembers how these dots are connected
    - When `fill()` or `stroke()` is reached, all dots are connected at once

<img src="imgs/canvas-path-demo.png" height="330px" style="float:right; margin-top: -10px; margin-left:15px"/>

    ctx.beginPath();
    ctx.lineTo(200, 50);
    ctx.lineTo(50, 50);
    ctx.stroke();
    ctx.beginPath();
    ctx.moveTo(200, 50);
    ctx.lineTo(200,300);
    ctx.lineTo(50, 300);
    ctx.closePath();
    ctx.fill();

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Using the Path
## Live Demo

<!-- Drawing Ellipses -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"drawing-ellipses" data-markdown class:"slide-section" } -->
# Drawing Ellipses
## Using the path

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Ellipses
- The Canvas has a built-in methods for drawing ellipses
- arc(x, y, radius, from, to, counterclockwise)
- Draws a circle with center at (x, y) from position "from" to position "to"
- Positions in ellipses are described using radians (degrees)
- The degrees to radians formula is:
    - **`radians = degrees * PI/180`**

<!-- attr: { hasScriptWrapper:true } -->
# Degrees and Radians
<div style="text-align: center; padding-top:5px">
    <img src="imgs/degrees-radians.png" width="600px"/>
</div>

<!-- attr: { hasScriptWrapper:true, style:"font-size: 40px" } -->
# Drawing Ellipses: Example
- To draw ellipses, a path must be started:

            ctx.beginPath();

        - Draw a full circle:

            //clockwise
            ctx.arc(x, y, r, 0, 2- Math.PI);
            //counter clockwise
            ctx.arc(x, y, r, 2- Math.PI, 0, true);

        - Draw a segment of an ellipse:

            //The smaller part (clockwise)
            ctx.arc(x, y, r, Math.PI/2, 2- Math.PI);

            //the bigger part (counterclockwise)
            ctx.arc(x, y, r, Math.PI/2, 2- Math.PI, true);
<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Drawing Ellipses and Segments
## Live Demo

<!-- attr: { hasScriptWrapper:true, style:"font-size: 40px" } -->
# Drawing Circular Sectors
- A circular sector is the portion of a circle enclosed by two radiuses
- The Canvas has no built-in methods for creating circular sectors
   - Yet, the Canvas supports paths
- A circle sector can be done by creating a sector and then a line to the center of the circle

<div style="text-align: center">
    <img src="imgs/drawing-ellipses-sector-small.png" width="250" style="margin-right:20px"/>
    <img src="imgs/drawing-ellipses-sector-big.png" width="250" />
</div>

<!-- attr: { hasScriptWrapper:true,  } -->
# Drawing Circular Sectors: Example
- **context.closePath()** connects the first and the last dots from the Path

    function drawSector(x, y, r, from, to, isCounterClockwise) {
      ctx.beginPath();
      ctx.arc(x, y, r, from, to, isCounterClockwise);
      ctx.lineTo(x, y);
      ctx.closePath();
      ctx.stroke();
    }

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Drawing Circular Sectors
## Live Demo

<!-- Drawing Curves -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"drawing-curves" data-markdown class:"slide-section" } -->
# Drawing Curves
## Quadratic and Bezier

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Curves with the Canvas
- The Canvas supports two types of curves:
    - **Quadratic** curves
        - A simple curve drawn based on a control point
    - **Bezier** curves
        - A more complex curve based on two control points
- Both quadratic and Bezier curves are done using a path

<!-- attr: { hasScriptWrapper:true } -->
# Quadratic Curves <!-- .element: style="margin-bottom: 45px" -->
- Quadratic curves are basic curves
    - Using **two context points** and a **control point**
        - The first is the last point from the path (sx, sy)
        - The second is the one from the curve (cx, cy)
    - `context.quadraticCurveTo(cx, cy, ex, ey)` <!-- .element: style="font-size: 0.9em" -->
<div style="text-align: center">
    <img src="imgs/qudratic-curve-sample.png" width="450px" />
</div>

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Quadratic Curves
## Live Demo

<!-- attr: { hasScriptWrapper:true } -->
# Bezier Curves <!-- .element: style="margin-bottom: 45px" -->
- Bezier curves are like quadratic curves, but with **two context** and **two control** points

<div style="text-align: center; margin-top: 15px">
    <img src="imgs/bezier-curve-sample.png" width="450px" style="border-radius: 15px; border: 1px solid black"/>
</div>

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Bezier Curves
## Live Demo

<!-- Drawing Text in canvas -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"drawing-text" data-markdown class:"slide-section" } -->
# Drawing Text in Canvas
## With styles

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Text
- The HTML5 canvas can also **draw text**:
    - Methods:
        - `context.fillText (text, x, y)` – fills the given text
        - `context.strokeText (text, x, y)` – draws only the border of the text
    - Properties:
        - `context.font` – sets the font size and font family of the text
        - `context.fillStyle` – the fill color of the text
        - `context.strokeStyle` – the stroke color of the text

<!-- attr: { hasScriptWrapper:true } -->
# Drawing Text: Example
- Draw the text 'Telerik Academy'
    - Filled with **yellowgreen** color, stroked with **dark green** color
    - Font family – `Arial`
    - Font sizes – from `28px` to `48px`

    var minFontSize = '28';
    var currentFontSize = 48;
    while (minFontSize <= currentFontSize) {
      ctx.font = currentFontSize + 'px ' + 'Arial';
      ctx.fillText(text, x, y);
      ctx.strokeText(text, x, y);
      y += currentFontSize + offset;
      currentFontSize -= 4;
    }

<img class="fragment" src="imgs/drawing-text-demo.png" width="300" style="position: absolute; top: 30%; left: 70%" />

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Drawing Text in Canvas
## Live Demo

<!-- Canvas Styles -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"canvas-styles" data-markdown class:"slide-section" } -->
# Canvas Styles
## Colors and Stuff

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Styles
- The canvas supports two styles
    - Styles for **fill** and **stroke**
        - Can be either a solid color or pattern
    - Styles for **types of stroke**
        - Dashed or solid
        - Done using kind of workaround

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Canvas Styles
## Live Demo

<!-- Canvas Transformations -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"transformations" data-markdown class:"slide-section" } -->
# Canvas Transformations
## scale(), rotate()

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Transformations
- The Canvas can do transformations
    - i.e. it can be rotated, scaled or transformed
- `context.scale(dx, dy)` – all coordinates and points are scaled
    - `fillRect(X, X, W, H)` will draw a rectangle
    - At position **(dx * X, dy * Y)**
    - With width **(dx* W)** and height **(dy* H)**
- `context.rotate(D)` – all drawing is rotated with angle **D degrees**

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Canvas Transformations
## Live Demo

<!-- Per-pixel Manipulation -->
<!-- section start -->
<!-- attr: { hasScriptWrapper:true, id:"per-pixel-manipulation" class:"slide-section" } -->
# Canvas Per-pixel Manipulation
## Change only portions of the canvas

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Per-pixel Manipulation
- Canvas supports **per-pixel manipulation**
    - All the pixels can be **manipulated one-by-one**
- Use the `context.getImageData(x, y, w, h)` <!-- .element: style="font-size: 40px" -->
    - Returns the image data object
        - The image data is for the rectangle with **top-left corner at (x, y)** with **width w** and **height h**
    - The image data contains **an array of numbers** for each of the pixels

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Per-pixel Manipulation (2)
- The array of pixels holds values between `0` and `255`
    - Each value represents a **color component** from **RGBA**
    - The pixels are grouped in triples in the array
    - The color values for the **i-th pixel** are at positions:
        - `pixels[i]` holds the **RED** component
        - `pixels[i+1]` holds the **GREEN** component
        - `pixels[i+2]` holds the **BLUE** component

<!-- attr: { hasScriptWrapper:true } -->
# Canvas Per-pixel Manipulation: Example
- Invert all the colors of an canvas
    - Change each color component `CC` with `255-CC`

    var i,
        len,
        width = canvas.width,
        height = canvas.height,
        imageData = ctx.getImageData(150, 150, width, height),
        data = imageData.data;
    for(i = 0, len = data.length; i < len; i+=4){
        data[i+1] = 255 - data[i+1];
        data[i] = 255 - data[i];
        data[i+2] = 255 - data[i+2];
    }
    ctx.putImageData(imageData, 0, 0);

<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# Canvas Per-pixel Manipulations
## Live Demo

<!-- attr: { hasScriptWrapper:true, id:"questions" class:"slide-questions" } -->
# The HTML5 Canvas
## Questions
