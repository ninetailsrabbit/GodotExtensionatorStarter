shader_type canvas_item;

uniform vec4 color_gap: source_color = vec4(0.25);
uniform vec4 color_stripe: source_color = vec4(1.0, 0.75, 0.0, 1.0);
uniform float divisions = 8.0; 
uniform float stripe_bias = 2.5;
uniform float speed = 0.1;
uniform float angle = 0.7854; 

void fragment() {
	float w = cos(angle) * UV.x + sin(angle) * UV.y - speed * TIME;
	
	if (floor(mod(w * divisions, stripe_bias)) < 0.0001) {
		COLOR = color_gap;
	} else {
		COLOR = color_stripe;
	}
}